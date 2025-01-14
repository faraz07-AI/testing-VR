using System.Data.SQLite;
using Moq;
using System.Reflection;
using System.Threading;
using System.Globalization;
using InterfaceFactory;
using VirtualRadar.Interface.Settings;
using VirtualRadar.Interface;
using VirtualRadar.Interface.StandingData;

namespace Test.VirtualRadar.Database
{
    [TestClass]
    public class CidrTests
    {
        #region TestContext, Fields, TestInitialise
        public TestContext TestContext { get; set; }
        #endregion

        #region GetExcelIPAddress
        private IPAddress GetExcelIPAddress(ExcelWorksheetData worksheet, string columnName)
        {
            var expected = worksheet.String(columnName);
            var result = IPAddress.Parse(expected);

            return result;
        }
        [TestMethod]
        public void SQLite_BaseStationDatabase_GetOrInsertAircraftByCode_Correctly_Inserts_Record()
        {
           BaseStationDatabase_GetOrInsertAircraftByCode_Correctly_Inserts_Record();
        }
    
        [TestMethod]
        public void SQLite_BaseStationDatabase_GetFlights_Ignores_Unknown_Sort_Columns()
        {
           BaseStationDatabase_GetFlights_Ignores_Unknown_Sort_Columns();
        }
    
        [TestMethod]
        public void SQLite_BaseStationDatabase_GetOrInsertAircraftByCode_Deals_With_Null_Country()
        {
           BaseStationDatabase_GetOrInsertAircraftByCode_Deals_With_Null_Country();
        }
    
        [TestMethod]
        public void SQLite_BaseStationDatabase_GetFlights_Some_Criteria_Is_Case_Insensitive()
        {
           BaseStationDatabase_GetFlights_Some_Criteria_Is_Case_Insensitive();
        }
   
        [TestMethod]
        public void SQLite_BaseStationDatatbase_GetManyAircraftByCode_Returns_Empty_Collection_If_Passed_Null()
        {
           BaseStationDatatbase_GetManyAircraftByCode_Returns_Empty_Collection_If_Passed_Null();
        }

    
        [UnityTest]
        public IEnumerator CollidingWithCherryIncreasesScore()
        {
           GameObject cherry = MonoBehaviour.Instantiate(Resources.Load<GameObject>("Tests/Prefabs/Pickups/Cherry"));
           int score = pacmanScore.GetScore();
           pacman.transform.position = cherry.transform.position;
           yield return new WaitForSeconds(WAIT_TIME);
           Assert.AreEqual(score + Constants.FRUIT_EATEN_SCORE, pacmanScore.GetScore());
           Object.Destroy(cherry);
        }
      }
