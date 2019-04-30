using System;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace CodedUITestProject
{
    /// <summary>
    /// Summary description for AdminTest
    /// </summary>
    [CodedUITest]
    public class AdminTest
    {
        [ClassInitialize]
        public static void Initialize(TestContext context)
        {
            Playback.Initialize();
            var bw = BrowserWindow.Launch(new Uri("http://localhost:63418"));
            bw.CloseOnPlaybackCleanup = false;
        }


        [TestMethod]
        public void AdminTests()
        {
            UiMap.AdminLogIn();

            UiMap.LookAtLinq();
            UiMap.SendFeedback();
            UiMap.CreateUser();
            UiMap.EditUserAddEmail();
            UiMap.AddNewRole();
            UiMap.EditNewRole();
            UiMap.AddUserToRole();
            UiMap.EditGame();

            UiMap.AddNewGame();
            UiMap.EditCategory2();
            UiMap.AddNewCategory();

            UiMap.AdminLogOut();
            // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext { get; set; }

        public UIMap UiMap => _map ?? (_map = new UIMap());

        private UIMap _map;
    }
}
