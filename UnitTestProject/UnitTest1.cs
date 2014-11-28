using System;
using System.Collections.Generic;
using JohannesVidnerProject.Controllers;
using JohannesVidnerProject.Models.Home;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Services;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        //test of a search by only one word, with top administrator level.
        [TestMethod]
        public void TestSearchTopLevelOneWord()
        {
            var hc = new HomeController();
            var hcPo = new PrivateObject(hc);
            var ivModel = new IndexViewModel();
            var user = DbService.Instance.GetUserById(1);

            ivModel.q = "ipsum";

            var outVm = (IndexViewModel) hcPo.Invoke("FillViewModel", 
                                                     ivModel, 
                                                     user.Publication);
            Assert.AreEqual(6, outVm.PublicationViewModels.Count);
        }

        //Test of a search by more than one word, with top administrator level. Should only return the publications that contains all the words.
        [TestMethod]
        public void TestSearchTopLevelManyWords()
        {
            var hc = new HomeController();
            var hcPo = new PrivateObject(hc);
            var ivModel = new IndexViewModel();
            var user = DbService.Instance.GetUserById(1);

            ivModel.q = "ipsum llc";
            var outVm = (IndexViewModel)hcPo.Invoke("FillViewModel",
                                                     ivModel,
                                                     user.Publication);
            Assert.AreEqual(2, outVm.PublicationViewModels.Count);
        }

        //Test of selecting a publication in the dropdown list, and only searching among the children of that one.
        [TestMethod]
        public void TestSearchLowerLevel()
        {
            var hc = new HomeController();
            var hcPo = new PrivateObject(hc);
            var ivModel = new IndexViewModel();
            var user = DbService.Instance.GetUserById(1);

            ivModel.p = 3;
            ivModel.q = "in";
            
            var outVm = (IndexViewModel)hcPo.Invoke("FillViewModel",
                                                     ivModel,
                                                     user.Publication);
            Assert.AreEqual(1, outVm.PublicationViewModels.Count);
        }




    }
}
