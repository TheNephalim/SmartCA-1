using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;
using SmartCA.Model.Projects;

namespace SmartCA.Infrastructure.Repositories
{
    public class ContactRepository :SqlCeRepositoryBase<Contact>, IContactRepository
    {
        #region Constructors

        public ContactRepository():this(null)
        {
        }

        public ContactRepository(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #endregion

        #region GetBaseQuery
        protected override string GetBaseQuery()
        {
            return "SELECT * FROM Contact";
        }

        protected override string GetBaseWhereClause()
        {
            return " WHERE ContactID = '{0}';";
        }

        #endregion

        #region UnitOfWork Implementation

        protected override void PersistNewItem(Contact item)
        {
            throw new Exception("The method or operation is not implemented.");
            StringBuilder builder = new StringBuilder(100);
            builder.Append(string.Format("INSERT INTO Contact ({0} ,{1} ,{2} ,{3} ,{4} ,{5} ,{6})"
                                         , ContactFactory.FieldNames.ContactId
                                         , ContactFactory.FieldNames.FirstName
                                         , ContactFactory.FieldNames.LastName
                                         , ContactFactory.FieldNames.JobTitle
                                         , ContactFactory.FieldNames.Phone
                                         , ContactFactory.FieldNames.MobilePhone
                                         , ContactFactory.FieldNames.Fax
                                         , ContactFactory.FieldNames.Email
                                         , ContactFactory.FieldNames.Remarks));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        protected override void PersistUpdateItem(Contact item)
        {
            
            throw new Exception("The method or operation is not implemented.");
            StringBuilder builder = new StringBuilder(100);
            builder.Append("UPDATE Company SET ");
            builder.Append(string.Format(" {0} = {1}"));
            builder.Append(string.Format(", {0} = {1}"));
            builder.Append(string.Format(", {0} = {1}"));
            builder.Append(string.Format(", {0} = {1}"));
            builder.Append(string.Format(", {0} = {1}"));
            builder.Append(" ");
            builder.Append(this.BuildBaseWhereClause(item.Key));

            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(builder.ToString()));
        }

        protected override void PersistDeletedItem(Contact item)
        {
            string query = string.Format("DELETE Contact {0}", BuildBaseWhereClause(item.Key));
            this.Database.ExecuteNonQuery(this.Database.GetSqlStringCommand(query));
        }

        #endregion

        #region Child Callbacks

        protected override void BuildChildCallbacks()
        {
            this.ChildCallbacks.Add("addresses",
                                    delegate(Contact contact, object childKeyName)
                                    {
                                        AppendAddresses(contact);
                                    });
        }

        private void AppendAddresses(Contact contact)
        {
            string sql =
                string.Format("SELECT * FROM ContactAddress WHERE ContactID = '{0}'", contact.Key);
            using (IDataReader reader = this.ExecuteReader(sql))
            {
                while (reader.Read())
                {
                    contact.Addresses.Add(AddressFactory.BuildAddress(reader));
                }
            }
        }

        #endregion
    }
}
