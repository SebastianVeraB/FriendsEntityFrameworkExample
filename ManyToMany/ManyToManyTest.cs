using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Entities;
using DataAccess;
using System.Collections.Generic;
using System.Linq;

namespace ManyToMany
{
    [TestClass]
    public class ManyToManyTest
    {
        private AgendaDataAccess dataAccess;
        private Agenda agenda1;
        private Agenda agenda2;
        private User contact1;
        private User contact2;
        private User owner;
        List<User> contacts;

        [TestInitialize]
        public void SetUp()
        {
            dataAccess = new AgendaDataAccess();
            contact1 = new User { Name = "Juan", Age = 31 };
            contact2 = new User { Name = "Maria", Age = 40 };
            owner = new User { Name = "Owner", Age = 50};

            agenda1 = new Agenda { Name = "Familia 2018" };
            agenda2 = new Agenda { Name = "Trabajo 2018" };
            contacts = new List<User>();
        }

       [TestCleanup]
        public void CleanUp()
        {
            IEnumerable<Agenda> agendas = dataAccess.GetAll();
           
            foreach(Agenda agenda in agendas)
            {
                Guid agendaId = agenda.Id;
                Agenda agendaToDelete = dataAccess.Get(agendaId);
               
                dataAccess.Delete(agendaToDelete);
            }

            IEnumerable<User> users = dataAccess.GetAllUser();
            foreach(User user in users)
            {
                dataAccess.DeleteUser(user);
            }
           
        }

        [TestMethod]
        public void TestAddTwoContactsToOneAgenda()
        {
            agenda1.Owner = owner;
            contacts.Add(contact1);
            contacts.Add(contact2);
            agenda1.Contacts = contacts;

            dataAccess.Add(agenda1);
            IEnumerable<Agenda> agendas = dataAccess.GetAll();
            

            Assert.AreEqual(agendas.Last(), agenda1);

        }

        [TestMethod]
        public void TestAddOneContactToTwoAgendas()
        {
            agenda1.Owner = owner;
            agenda2.Owner = owner;

            contacts.Add(contact1);
            agenda1.Contacts = contacts;
            agenda2.Contacts = contacts;
            dataAccess.Add(agenda1);
            dataAccess.Add(agenda2);
        }
    }
}
