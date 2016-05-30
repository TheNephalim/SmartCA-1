using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmartCA.Infrastructure;
using SmartCA.Infrastructure.RepositoryFramework;
using SmartCA.Model.Companies;

namespace SmartCA.Model.Contacts
{
    public static class ContactService
    {
        private static IContactRepository repository;
        private static IUnitOfWork unitOfWork;

        static ContactService()
        {
            ContactService.unitOfWork = new UnitOfWork();
            ContactService.repository = RepositoryFactory.GetRepository<IContactRepository, Contact>(unitOfWork);
        }

        private static void SaveContact(Contact contact)
        {
            repository[contact.Key] = contact;
            ContactService.unitOfWork.Commit();
        }
    }
}
