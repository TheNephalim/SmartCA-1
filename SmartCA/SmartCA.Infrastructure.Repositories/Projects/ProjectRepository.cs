using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using SmartCA.Infrastructure.DomainBase;
using SmartCA.Infrastructure.EntityFactoryFramework;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;
using SmartCA.Model.Employees;
using SmartCA.Model.Projects;

namespace SmartCA.Infrastructure.Repositories
{
    public class ProjectRepository : SqlCeRepositoryBase<Project>, IProjectRepository
    {

        #region Private fields
        #endregion

        #region Public Constructors

        public ProjectRepository():this(null)
        {
        }

        public ProjectRepository(IUnitOfWork unitOfWork):base(unitOfWork)
        {
        }

        #endregion

        #region IProjectRepository inpementation

        public IList<Project> FindBy(IList<MarketSegment> segments, bool completed)
        {
            StringBuilder builder = this.GetBaseQueryBuilder();
            if (completed)
            {
                builder.Append(" WHERE p.ActualCompletionDate IS NOT NULL AND p.PercentComplete > 99");
            }
            else
            {
                builder.Append(" WHERE p.ActualCompletionDate IS NULL AND p.PercentComplete < 100");
            }
            if (segments != null || segments.Count > 0)
            {
                builder.Append(string.Format(" AND p.MarketSegmentID IN ({0})",
                                             DataHelper.EntityListToDelimited(segments)));
            }
            builder.Append(";");
            return this.BuildEntitiesFromSql(builder.ToString());
        }

        public Project FindBy(string projectNumber)
        {
            StringBuilder builder = this.GetBaseQueryBuilder();
            return
                this.BuildEntityFromSql(
                    builder.Append(string.Format(" WHERE p.ProjectNumber = N'{0}';", projectNumber)).ToString());
        }

        public IList<MarketSegment> FindAllMarketSegments()
        {
            List<MarketSegment> segments = new List<MarketSegment>();
            string query = @"SELECT * 
                            FROM MarketSegment mst
                                INNER JOIN MarketSector msr
                                ON mst.MarketSectorID = msr.MarketSectorID;";
            IEntityFactory<MarketSegment> factory = EntityFactoryBuilder.BuildFactory<MarketSegment>();
            using (IDataReader reader = this.ExecuteReader(query))
            {
                while (reader.Read())
                {
                    segments.Add(factory.BuildEntity(reader));
                }
            }
            return segments;
        }

        public void SaveContact(ProjectContact contact)
        {
            List<ProjectContact> contacts = new List<ProjectContact>(this.FindBy(contact.Project.Key).Contacts);
            if (contacts.Where(c => c.Key.Equals(contact.Key)).Count() > 0)
            {
                this.UnitOfWork.RegisterChanged(contact, this);
            }
            else
            {
                this.UnitOfWork.RegisterAdded(contact, this);
            }
        }

        #endregion

        #region BuildChildCallbacks
        protected override void BuildChildCallbacks()
        {
            this.ChildCallbacks.Add(ProjectFactory.FieldNames.OwnerCompanyId, this.AppendOwner);
            this.ChildCallbacks.Add(ProjectFactory.FieldNames.ConstructionAdministratorEmployeeId, this.AppendConstructionAdministrator);
            this.ChildCallbacks.Add(ProjectFactory.FieldNames.PrincipalEmployeeId, this.AppendPrincipal);
            this.ChildCallbacks.Add("allowances", delegate(Project project, object childKeyName)
                {
                    this.AppendProjectAllowances(project);
                });
        }
        #endregion

        #region ChildCallbacks instance

        public void AppendOwner(Project project, object ownerCompanyId)
        {
            ICompanyRepository repository = RepositoryFactory.GetRepository<ICompanyRepository, Company>(this.UnitOfWork);
            project.Owner = repository.FindBy(ownerCompanyId);
        }

        private void AppendConstructionAdministrator(Project project, object constructionAdministratorId)
        {
            project.ConstructionAdministrator = this.GetEmployee(constructionAdministratorId);
        }

        private void AppendPrincipal(Project project, object principalId)
        {
            project.PrincipalInCharge = this.GetEmployee(principalId);
        }

        private void AppendProjectAllowances(Project project)
        {
            string sql = string.Format("select * from ProjectAllowance where ProjectID = '{0}'", project.Key);

            using (IDataReader reader = this.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    project.Allowances.Add(ProjectFactory.BuildAllowance(reader));
                }
            }
        }

        private Employee GetEmployee(object employeeId)
        {
            //IEmployeeRepository repository = RepositoryFactory.GetRepository<IEmployeeRepository, Employee>();
            //return repository.FindBy(employeeId);
            return null;
        }

        #endregion

        #region UnitOfWork implementation


        public override void PersistNewItem(IEntity item)
        {
            Project project = item as Project;
            if (project != null)
            {
                PersistNewItem(project);
            }
            else
            {
                ProjectContact contact = item as ProjectContact;
                this.PersistNewItem(contact);
            }
        }

        protected override void PersistNewItem(Project item)
        {
            StringBuilder builder = GetBaseQueryBuilder();
            builder.Append(string.Format(@"
INSERT INTO Project 
({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26})  "
                                        , ProjectFactory.FieldNames.ProjectId
                                        , ProjectFactory.FieldNames.ProjectNumber
                                        , ProjectFactory.FieldNames.ProjectName
                                        , ProjectFactory.FieldNames.ConstructionAdministratorEmployeeId
                                        , ProjectFactory.FieldNames.PrincipalEmployeeId
                                        , ProjectFactory.FieldNames.ProjectAddress
                                        , ProjectFactory.FieldNames.ProjectCity
                                        , ProjectFactory.FieldNames.ProjectState
                                        , ProjectFactory.FieldNames.ProjectPostalCode
                                        , ProjectFactory.FieldNames.OwnerCompanyId
                                        , ProjectFactory.FieldNames.ContractDate
                                        , ProjectFactory.FieldNames.EstimatedStartDate
                                        , ProjectFactory.FieldNames.EstimatedCompletionDate
                                        , ProjectFactory.FieldNames.ActualCompletionDate
                                        , ProjectFactory.FieldNames.ContigencyAllowanceAmount
                                        , ProjectFactory.FieldNames.TestingAllowanceAmount
                                        , ProjectFactory.FieldNames.UtilityAllowanceAmount
                                        , ProjectFactory.FieldNames.OriginalConstructionCost
                                        , ProjectFactory.FieldNames.AeChangeOrderAmount
                                        , ProjectFactory.FieldNames.TotalSquareFeet
                                        , ProjectFactory.FieldNames.PercentComplete
                                        , ProjectFactory.FieldNames.Remarks
                                        , ProjectFactory.FieldNames.ContractReason
                                        , ProjectFactory.FieldNames.AgencyApplicationNumber
                                        , ProjectFactory.FieldNames.AgencyFileNumber
                                        , ProjectFactory.FieldNames.MarketSegmentId));
            builder.Append(string.Format(@" VALUES ({0}, {1}, {2}, {3}, {4}, {5}, {6}, {7}, {8}, {9}, {10}, {11}, {12}, {13}, {14}, {15}, {16}, {17}, {18}, {19}, {20}, {21}, {22}, {23}, {24}, {25}, {26})  "
                                        , item.Key
                                        , item.Number
                                        , item.Name
                                        , item.ConstructionAdministrator.Key
                                        , item.PrincipalInCharge.Key
                                        , item.Address.Street
                                        , item.Address.City
                                        , item.Address.State
                                        , item.Address.PostalCode
                                        , item.Owner.Key
                                        , item.ContractDate
                                        , item.EstimatedStartDate
                                        , item.EstimatedCompletionDate
                                        , item.ActualCompletionDate
                                        , item.ContigencyAllowanceAmount
                                        , item.TestingAllowanceAmount
                                        , item.UtilityAllowanceAmount
                                        , item.OriginalConstructionCost
                                        , item.AeChangeOrderAmount
                                        , item.TotalSquareFeet
                                        , item.PercentComplete
                                        , item.Remarks
                                        , item.ContractReason
                                        , item.AgencyApplicationNumber
                                        , item.AgencyFileNumber
                                        , item.Segment.Key));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        protected void PersistNewItem(ProjectContact contact)
        {
            StringBuilder builder = new StringBuilder(100);
            builder.Append(string.Format("INSERT INTO ProjectContact ({0}, {1}, {2}) ",
                                         ProjectFactory.FieldNames.ProjectId, 
                                         ContactFactory.FieldNames.ContactId,
                                         contact.OnFinalDistributionList));
            builder.Append(string.Format("VALUES ({0}, {1}, {2});",
                                         DataHelper.GetSqlValue(contact.Project.Key),
                                         DataHelper.GetSqlValue(contact.Contact.Key),
                                         DataHelper.GetSqlValue(contact.OnFinalDistributionList)));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        public override void PersistUpdateItem(IEntity item)
        {
            Project project = item as Project;
            if (project != null)
            {
                PersistUpdateItem(project);
            }
            else
            {
                PersistUpdateItem(item as ProjectContact);
            }
        }

        protected override void PersistUpdateItem(Project item)
        {
            StringBuilder builder = GetBaseQueryBuilder();
            builder.Append("UPDATE Project SET ");
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectNumber, DataHelper.GetSqlValue(item.Number)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectName, DataHelper.GetSqlValue(item.Name)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ConstructionAdministratorEmployeeId, item.ConstructionAdministrator.Key));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.PrincipalEmployeeId, item.PrincipalInCharge.Key));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectAddress, item.Address.Street));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectCity, item.Address.City));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectState, item.Address.State));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectPostalCode, item.Address.PostalCode));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.OwnerCompanyId, item.Owner.Key));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ContractDate, DataHelper.GetSqlValue(item.ContractDate)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.EstimatedStartDate, DataHelper.GetSqlValue(item.EstimatedStartDate)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.EstimatedCompletionDate, DataHelper.GetSqlValue(item.EstimatedCompletionDate)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ActualCompletionDate, DataHelper.GetSqlValue(item.ActualCompletionDate)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ContigencyAllowanceAmount, DataHelper.GetSqlValue(item.ContigencyAllowanceAmount)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.TestingAllowanceAmount, DataHelper.GetSqlValue(item.TestingAllowanceAmount)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.UtilityAllowanceAmount, DataHelper.GetSqlValue(item.UtilityAllowanceAmount)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.OriginalConstructionCost, DataHelper.GetSqlValue(item.OriginalConstructionCost)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.AeChangeOrderAmount, DataHelper.GetSqlValue(item.AeChangeOrderAmount)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.TotalSquareFeet, DataHelper.GetSqlValue(item.TotalSquareFeet)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.PercentComplete, DataHelper.GetSqlValue(item.PercentComplete)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.Remarks, DataHelper.GetSqlValue(item.Remarks)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ContractReason, DataHelper.GetSqlValue(item.ContractReason)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.AgencyApplicationNumber, DataHelper.GetSqlValue(item.AgencyApplicationNumber)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.AgencyFileNumber, DataHelper.GetSqlValue(item.AgencyFileNumber)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.MarketSegmentId, item.Segment.Key));
            builder.Append(" ");
            builder.Append(this.BuildBaseWhereClause(item.Key));

            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        protected void PersistUpdateItem(ProjectContact item)
        {
            StringBuilder builder = GetBaseQueryBuilder();
            builder.Append("UPDATE ProjectContact SET ");
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.ProjectId, DataHelper.GetSqlValue(item.Project)));
            builder.Append(string.Format("{0} = {1}", ContactFactory.FieldNames.ContactId, DataHelper.GetSqlValue(item.Contact)));
            builder.Append(string.Format("{0} = {1}", ProjectFactory.FieldNames.OnFinalDistributionList, DataHelper.GetSqlValue(item.OnFinalDistributionList)));
            builder.Append(" ");
            builder.Append(this.BuildBaseWhereClause(item.Key));
        }

        public override void PersistDeletedItem(IEntity item)
        {
            Project project = item as Project;
            if (project != null)
            {
                PersistDeletedItem(project);
            }
            else
            {
                PersistDeletedItem(item as ProjectContact);
            }
        }

        protected override void PersistDeletedItem(Project item)
        {
            string query = string.Format("DELETE FROM ProjectAllowance {0}", this.BuildBaseWhereClause(item.Key));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(query));
            query = string.Format("DELETE FROM Project {0}", this.BuildBaseWhereClause(item.Key));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(query));
        }

        protected void PersistDeletedItem(ProjectContact item)
        {
            string query = string.Format("DELETE FROM ProjectContact {0}", this.BuildBaseWhereClause(item.Project.Key));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(query));
        }

        #endregion

        #region GetBaseQuery
        protected override string GetBaseQuery()
        {
            return @"
select * 
from Project p 
    inner join MarketSegment ms
    on p.MarketSegmentId = ms.MarketSegmentID";
        }
        #endregion

        #region GetBaseWhereClause
        protected override string GetBaseWhereClause()
        {
            return " where ProjectID = '{0}';";
        }
        #endregion



    }
}
