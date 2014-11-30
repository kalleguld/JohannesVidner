using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using JohannesVidnerProject;
using JohannesVidnerProject.Controllers;
using JohannesVidnerProject.Models.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Moq;
using Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void TestObscureSearch()
        {
            var inViewModel = new IndexViewModel{q = "sdhfsjfsvkjbsdgfsuh"};
            var user = DbService.Instance.GetUserById(1);

            var outViewModel = StartHomeController(inViewModel, user);
            Assert.AreEqual(0, outViewModel.PublicationViewModels.Count);
        }

        


        //test of a search by only one word, with top administrator level.
        [TestMethod]
        public void TestSearchTopLevelOneWord()
        {
            var user = DbService.Instance.GetUserById(1);
            var ivModel = new IndexViewModel {q = "ipsum"};

            var outVm = StartHomeController(ivModel, user);

            Assert.AreEqual(6, outVm.PublicationViewModels.Count);
        }

        //Test of a search by more than one word, with top administrator level. Should only return the publications that contains all the words.
        [TestMethod]
        public void TestSearchTopLevelManyWords()
        {
            var user = DbService.Instance.GetUserById(1);
            var ivModel = new IndexViewModel {q = "ipsum llc"};

            var outVm = StartHomeController(ivModel, user);

            Assert.AreEqual(2, outVm.PublicationViewModels.Count);
        }

        //Test of selecting a publication in the dropdown list, and only searching among the children of that one.
        [TestMethod]
        public void TestSearchLowerLevel()
        {
            var user = DbService.Instance.GetUserById(1);
            var ivModel = new IndexViewModel
            {
                p = 3, 
                q = "in"
            };

            var outVm = StartHomeController(ivModel, user);

            Assert.AreEqual(1, outVm.PublicationViewModels.Count);
        }


        private static IndexViewModel StartHomeController(IndexViewModel inViewModel, User user)
        {
            var controller = new HomeController();
            var mockSession = new MockSession();
            SetFakeSession(controller, mockSession);

            mockSession.SetCurrentUser(user);

            var viewResult = (ViewResult)controller.Index(inViewModel);
            var outViewModel = (IndexViewModel)viewResult.Model;
            return outViewModel;
        }

        private static void SetFakeSession(ControllerBase controller, HttpSessionStateBase mockSession)
        {
            //The Mock class is part of Moq, found on NuGet
            var mockHttpContextBase = new Mock<HttpContextBase>();
            mockHttpContextBase.SetupGet(hcb => hcb.Session).Returns(mockSession);
            var mockControllerContext = new Mock<ControllerContext>();
            mockControllerContext.SetupGet(hcc => hcc.HttpContext).Returns(mockHttpContextBase.Object);
            controller.ControllerContext = mockControllerContext.Object;
        }

    }

    class MockSession : HttpSessionStateBase
    {
        readonly Dictionary<string, object> _dict = new Dictionary<string, object>(); 
        override public object this[string key]
        {
            get { return _dict[key]; }
            set { _dict[key] = value; }
        }
    }
}
