using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;
using SmartCA.Model.Contacts;

namespace SmartCA.UnitTests.Companies
{
    [TestClass]
    public class ContactRepositoryTest
    {
        private TestContext testContextInstance;
        private IUnitOfWork unitOfWork;
        private IContactRepository repository;
        private object testContactKey = "81d87051-f564-48be-a91c-44696074e2cc";

        [TestInitialize]
        public void MyTestInitialize()
        {
            this.unitOfWork = new UnitOfWork();
            this.repository = RepositoryFactory.GetRepository<IContactRepository, Contact>(this.unitOfWork);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindByKeyTest()
        {
            Contact Contact = this.repository.FindBy(testContactKey);
            Assert.AreEqual("My Contact", Contact.FirstName);
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void FindAllTest()
        {
            IList<Contact> contacts = this.repository.FindAll();
            Assert.AreEqual(1, contacts.Count);
        }
        
        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void AddTest()
        {
            Contact Contact = new Contact(new Guid());
            Contact.FirstName = "My Test Contact";
            
            repository.Add(Contact);
            this.unitOfWork.Commit();

            Contact savedContact = this.repository.FindBy(Contact.Key);
            Assert.AreEqual("My Test Contact", savedContact.FirstName);

            this.repository.Remove(savedContact);
            this.unitOfWork.Commit();
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void UpdateTest()
        {
            Contact Contact = repository.FindBy(testContactKey);
            string ContactName = Contact.FirstName;

            Contact.FirstName = "My Updated Contact";
            repository[Contact.Key] = Contact;
            this.unitOfWork.Commit();

            Contact savedContact = this.repository.FindBy(Contact.Key);
            Assert.AreEqual("My Updated Contact", savedContact.FirstName);

            savedContact.FirstName = ContactName;
            repository[savedContact.Key] = savedContact;
            unitOfWork.Commit();
        }

        [DeploymentItem("SmartCA.sdf"), TestMethod]
        public void RemoveTest()
        {
            Contact Contact = repository.FindBy(testContactKey);
            this.repository.Remove(Contact);
            unitOfWork.Commit();

            IList<Contact> contacts = repository.FindAll();
            Assert.AreEqual(1, contacts.Count);

            repository.Add(Contact);
            unitOfWork.Commit();
        }
    }
}
