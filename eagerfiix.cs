using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Test.Framework;
using VirtualRadar.Interface;

namespace Test.VirtualRadar.Interface
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
        public void Cidr_GetHashCode_Returns_Same_Value_For_Equals_CIDRs()
        {
            var obj1 = Cidr.Parse("1.2.3.4/32");
            var obj2 = Cidr.Parse("1.2.3.4/32");
            Assert.AreEqual(obj1.GetHashCode(), obj1.GetHashCode2());
        }
        #endregion

        [Test]
        public void IncrementPropertyGlobal()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            GameObject target = new GameObject("TransformEulerRotationMutatorTest");

            subject.Target = target;
            subject.UseLocalValues = false;
            subject.MutateOnAxis = Vector3State.True;

            Assert.That(target.transform.eulerAngles, Is.EqualTo(Vector3.zero).Using(comparer));

            Vector3 input = new Vector3(10f, 20f, 30f);
            subject.IncrementProperty(input);

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input).Using(comparer));

            subject.IncrementProperty(input);

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input * 2f).Using(comparer));

            Object.DestroyImmediate(target);
        }
        
        [Test]
        public void T999_FinishStatus()
        {
            TestHelper.InMethod();
            // Of the 4 assets "sent", only 2 sent the first part.
            Assert.That(client.sentdatapkt.Count,Is.EqualTo(2));

            // Sum of all packets sent:
            int totalpkts = (npackets) + (npackets - 2) + (npackets - 4);
            Assert.That(client.sentpktpkt.Count,Is.EqualTo(totalpkts));
        }

        
        [Test]
        public void Test01_TestAddCustomMappings()
        {
            InputMappingAxisUtility.CheckUnityInputManagerMappings(ControllerMappingUtilities.UnityInputManagerAxes);

            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_1));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_2));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_4));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_5));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_9));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_10));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_11));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_12));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_13));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_14));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_15));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_16));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_17));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_18));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_19));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_20));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_21));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_22));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_23));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_24));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_25));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_26));
            Assert.IsTrue(InputMappingAxisUtility.DoesAxisNameExist(ControllerMappingLibrary.AXIS_27));
        }
        
        [Test]
        public IEnumerator Exists()
        {
            // Given a file in a relative path.
            // When checking if the file exits.
            // Then assert that the file exits.
            Assert.IsFalse(string.IsNullOrEmpty(RelativeFilePath));
            Assert.IsFalse(Path.IsPathRooted(RelativeFilePath));
            Assert.IsTrue(defaultFileSystem.Exists(RelativeFilePath));
            yield break;
        }

        [Test]
        public void CastPointsInsufficientBeamLength()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            UnityEventListenerMock castResultsChangedMock = new UnityEventListenerMock();
            subject.ResultsChanged.AddListener(castResultsChangedMock.Listen);
            subject.Origin = subject.gameObject;

            validSurface.transform.position = Vector3.forward * 5f;
            subject.MaximumLength = validSurface.transform.position.z / 2f;

            subject.ManualOnEnable();
            Physics.Simulate(Time.fixedDeltaTime);
            subject.Process();

            Vector3 expectedStart = Vector3.zero;
            Vector3 expectedEnd = Vector3.forward * subject.MaximumLength;

            Assert.That(subject.Points[0], Is.EqualTo(expectedStart).Using(comparer));
            Assert.That(subject.Points[1], Is.EqualTo(expectedEnd).Using(comparer));
            Assert.IsFalse(subject.TargetHit.HasValue);
            Assert.IsTrue(castResultsChangedMock.Received);
        }
        [Test]
        public void IncrementPropertyGlobal()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            GameObject target = new GameObject("TransformEulerRotationMutatorTest");
 
            subject.Target = target;
            subject.UseLocalValues = false;
            subject.MutateOnAxis = Vector3State.True;

            Assert.That(target.transform.eulerAngles, Is.EqualTo(Vector3.zero).Using(comparer));

            Vector3 input = new Vector3(10f, 20f, 30f);
            subject.IncrementProperty(input); // Method call 1

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input).Using(comparer));

            subject.IncrementProperty(input); // Method call 2

            Assert.That(target.transform.eulerAngles, Is.EqualTo(input * 2f).Using(comparer));

            Object.DestroyImmediate(target);
        }

    }
}
