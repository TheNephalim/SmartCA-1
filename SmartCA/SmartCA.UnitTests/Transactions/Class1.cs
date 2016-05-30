using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Infrastructure.Transactions;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;
using SmartCA.Model.Projects;

namespace SmartCA.UnitTests.Transactions
{
    class Class1
    {
    }
}
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;
using SmartCA.Model.Projects;

namespace SmartCA.UnitTests.Projects
{
    [TestClass]
    public class ClientTransactionRepositoryTest
    {
        private TestContext testContextInstance;

        [TestInitialize]
        public void MyTestInitialize()
        {
        }


        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void IClientTransactionRepositoryAddTest()
        {
            IClientTransactionRepository target = ClientTransactionRepositoryFactory.GetTransactionRepository();
            TransactionType type = TransactionType.Insert;
            Company entity = new Company();
            entity.Name = "Test 123";
            object unitOfWorkKey = Guid.NewGuid();
            target.Add(new ClientTransaction(unitOfWorkKey, type, entity));
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindPendingTransactionRepositoryTest()
        {
            this.IClientTransactionRepositoryAddTest();
            IClientTransactionRepository target = ClientTransactionRepositoryFactory.GetTransactionRepository();
            IList<ClientTransaction> transactions = target.FindPending();
            Assert.IsTrue(transactions.Count > 0);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void SetLastSycnhronizationTest()
        {
            IClientTransactionRepository target = ClientTransactionRepositoryFactory.GetTransactionRepository();
            target.SetLastSynchronization(DateTime.Now);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void GetLastSycnhronizationTest()
        {
            IClientTransactionRepository target = ClientTransactionRepositoryFactory.GetTransactionRepository();
            target.SetLastSynchronization(DateTime.Now);
            DateTime? lastSynchronization = target.GetLastSynchronization();
            Assert.IsTrue(lastSynchronization.HasValue);
            Assert.IsTrue(DateTime.Now > lastSynchronization.Value);
        }

    }
}
