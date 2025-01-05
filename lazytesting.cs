using Zinnia.Tracking.Velocity;
using Zinnia.Tracking.Velocity.Collection;
using UnityEngine.InputSystem;

namespace Test.Zinnia.Tracking.Velocity
{
    using NUnit.Framework;
    using System.Collections;
    using Test.Zinnia.Utility.Mock;
    using UnityEngine;
    using UnityEngine.TestTools;
    using UnityEngine.TestTools.Utils;

    public class VelocityTrackerProcessorTest
    {
        private GameObject containingObject;
        private VelocityTrackerProcessor subject;

        [SetUp]
        public void SetUp()
        {
            containingObject = new GameObject("VelocityTrackerProcessorTest");
            subject = containingObject.AddComponent<VelocityTrackerProcessor>();
        }

        [TearDown]
        public void TearDown()
        {
            Object.DestroyImmediate(containingObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromFirstActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(true, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(1f, 1f, 1f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromSecondActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(2f, 2f, 2f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromThirdActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(3f, 3f, 3f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetVelocityFromNoneActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [Test]
        public void GetVelocityWithoutTrackers()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));
        }

        [UnityTest]
        public IEnumerator GetActiveVelocityTrackerAfterGetVelocity()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            subject.GetVelocity();

            VelocityTrackerMock expectedResult = trackerThree;
            VelocityTrackerMock unexpectedResult = trackerOne;
            VelocityTrackerMock actualResult = (VelocityTrackerMock)subject.ActiveVelocityTracker;

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetActiveVelocityTrackerAfterGetAngularVelocity()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            subject.GetAngularVelocity();

            VelocityTrackerMock expectedResult = trackerTwo;
            VelocityTrackerMock unexpectedResult = trackerOne;
            VelocityTrackerMock actualResult = (VelocityTrackerMock)subject.ActiveVelocityTracker;

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromFirstActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(true, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(1f, 1f, 1f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromSecondActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(true, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(2f, 2f, 2f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromThirdActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(true, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(3f, 3f, 3f);
            Vector3 unexpectedResult = new Vector3(0f, 0f, 0f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [UnityTest]
        public IEnumerator GetAngularVelocityFromNoneActive()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            VelocityTrackerMock trackerOne = VelocityTrackerMock.Generate(false, new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f));
            VelocityTrackerMock trackerTwo = VelocityTrackerMock.Generate(false, new Vector3(2f, 2f, 2f), new Vector3(2f, 2f, 2f));
            VelocityTrackerMock trackerThree = VelocityTrackerMock.Generate(false, new Vector3(3f, 3f, 3f), new Vector3(3f, 3f, 3f));

            VelocityTrackerObservableList velocityTrackers = containingObject.AddComponent<VelocityTrackerObservableList>();
            yield return null;
            subject.VelocityTrackers = velocityTrackers;

            velocityTrackers.Add(trackerOne);
            velocityTrackers.Add(trackerTwo);
            velocityTrackers.Add(trackerThree);

            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));

            Object.DestroyImmediate(trackerOne.gameObject);
            Object.DestroyImmediate(trackerTwo.gameObject);
            Object.DestroyImmediate(trackerThree.gameObject);
        }

        [Test]
        public void GetAngularVelocityWithoutTrackers()
        {
            Vector3EqualityComparer comparer = new Vector3EqualityComparer(0.1f);
            Vector3 expectedResult = new Vector3(0f, 0f, 0f);
            Vector3 unexpectedResult = new Vector3(1f, 1f, 1f);
            Vector3 actualResult = subject.GetAngularVelocity();

            Assert.That(actualResult, Is.EqualTo(expectedResult).Using(comparer));
            Assert.That(actualResult, Is.Not.EqualTo(unexpectedResult).Using(comparer));
        }

        [Test]
        [Category("Utilities")]
        public void Utilities_CanParseNameAndParameterList()
        {
           Assert.That(NameAndParameters.Parse("name()").name, Is.EqualTo("name"));
           Assert.That(NameAndParameters.Parse("name()").parameters, Is.Empty);
           Assert.That(NameAndParameters.Parse("name").name, Is.EqualTo("name"));
           Assert.That(NameAndParameters.Parse("name").parameters, Is.Empty);
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").name, Is.EqualTo("Name"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters, Has.Count.EqualTo(3));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].name, Is.EqualTo("foo"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].name, Is.EqualTo("Bar"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].name, Is.EqualTo("blub"));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].type, Is.EqualTo(TypeCode.Boolean));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].type, Is.EqualTo(TypeCode.Int64));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].type, Is.EqualTo(TypeCode.Double));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[0].value.ToBoolean(), Is.EqualTo(true));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[1].value.ToInt64(), Is.EqualTo(123));
           Assert.That(NameAndParameters.Parse("Name(foo,Bar=123,blub=234.56)").parameters[2].value.ToDouble(), Is.EqualTo(234.56).Within(0.0001));
       }
        #region Constructors and Properties
        [TestMethod]
        public void WebSite_Constructor_Initialises_To_Known_State_And_Properties_Work()
        {
            _WebSite = Factory.Resolve<IWebSite>();
            Assert.IsNull(_WebSite.WebServer);
            TestUtilities.TestProperty(_WebSite, "BaseStationDatabase", null, _BaseStationDatabase.Object);
            TestUtilities.TestProperty(_WebSite, "StandingDataManager", null, _StandingDataManager.Object);
        }
        
        [Test]
        public void StandardEmission()
        {
            var wrapper = TestUtils.LoadMaterialWrapper("Standard_Emission.mat");
            Assert.AreEqual(typeof(StandardMaterial), wrapper.GetType());
            var setting = new ToonLitConvertSettings
            {
                mainTextureBrightness = 1.0f,
            };
            using (var tex = DisposableObject.New(wrapper.GenerateToonLitImage(setting)))
            using (var main = DisposableObject.New(TestUtils.LoadUncompressedTexture("albedo_1024px_png.png")))
            using (var emission = DisposableObject.New(TestUtils.LoadUncompressedTexture("emission_1024px.png")))
            using (var composed = DisposableObject.New(new Texture2D(main.Object.width, main.Object.height)))
            {
                var mainPixels = main.Object.GetPixels32();
                var emissionPixels = emission.Object.GetPixels32();
                var compose = mainPixels.Select((p, i) =>
                {
                    var e = emissionPixels[i];
                    var r = (byte)System.Math.Min(p.r + e.r, 255);
                    var g = (byte)System.Math.Min(p.g + e.g, 255);
                    var b = (byte)System.Math.Min(p.b + e.b, 255);
                    var a = (byte)System.Math.Min(p.a + e.a, 255);
                    return new Color32(r, g, b, a);
                }).ToArray();
                composed.Object.SetPixels32(compose);
                Assert.Less(TestUtils.MaxDifference(tex.Object, composed.Object), Threshold);
            }
        }

       [TestMethod]
        public void SQLite_BaseStationDatabase_FileIsEmpty_Returns_True_If_The_File_Is_Empty()
        {
            _FileSystem.AddFile(@"c:\tmp\file.sqb", new byte[0]);
            _Database.FileName = @"c:\tmp\file.sqb";

            Assert.IsTrue(_Database.FileIsEmpty());
        }
        
        [TestMethod]
        public void PictureDetail_Equals_Returns_True_When_Comparing_Identical_Objects()
        {
            var aircraft = new PictureDetail();
            Assert.AreEqual(true, aircraft.Equals(aircraft));
        }

         #region RemoveIndex
        [TestMethod]
        [ExpectedException(typeof(NotImplementedException))]
        public void NotifyList_RemoveIndex_Is_Not_Implemented()
        {
            _ObservableList.RemoveIndex(_ObservableValueDescriptor);
        }
        #endregion

        [Test]
        [Category("Actions")]
        public void Actions_WithMultipleBoundControls_CanHandleButtonPressesAndReleases()
        {
           InputSystem.settings.defaultButtonPressPoint = 0.5f;
  
           var gamepad = InputSystem.AddDevice<Gamepad>();

           var action = new InputAction(binding: "<Gamepad>/*trigger");
           action.Enable();

           Assert.That(action.IsPressed(), Is.False);
           Assert.That(action.WasPressedThisFrame(), Is.False);
           Assert.That(action.WasPerformedThisFrame(), Is.False);
           Assert.That(action.WasReleasedThisFrame(), Is.False);
           Assert.That(action.WasCompletedThisFrame(), Is.False);
           Assert.That(action.activeControl, Is.Null);

           Set(gamepad.leftTrigger, 1f);

           Assert.That(action.IsPressed(), Is.True);
           Assert.That(action.WasPressedThisFrame(), Is.True);
           Assert.That(action.WasPerformedThisFrame(), Is.True);
           Assert.That(action.WasReleasedThisFrame(), Is.False);
           Assert.That(action.WasCompletedThisFrame(), Is.False);
           Assert.That(action.activeControl, Is.SameAs(gamepad.leftTrigger));

           Set(gamepad.rightTrigger, 0.6f);

           Assert.That(action.IsPressed(), Is.True);
           Assert.That(action.WasPressedThisFrame(), Is.False);
           Assert.That(action.WasPerformedThisFrame(), Is.False);
           Assert.That(action.WasReleasedThisFrame(), Is.False);
           Assert.That(action.WasCompletedThisFrame(), Is.False);
           Assert.That(action.activeControl, Is.SameAs(gamepad.leftTrigger));

           Set(gamepad.leftTrigger, 0f);

           Assert.That(action.IsPressed(), Is.True);
           Assert.That(action.WasPressedThisFrame(), Is.False);
           Assert.That(action.WasPerformedThisFrame(), Is.True);
           Assert.That(action.WasReleasedThisFrame(), Is.False);
           Assert.That(action.WasCompletedThisFrame(), Is.False);
           Assert.That(action.activeControl, Is.SameAs(gamepad.rightTrigger));

           Set(gamepad.rightTrigger, 0f);

           Assert.That(action.IsPressed(), Is.False);
           Assert.That(action.WasPressedThisFrame(), Is.False);
           Assert.That(action.WasPerformedThisFrame(), Is.False);
           Assert.That(action.WasReleasedThisFrame(), Is.True);
           Assert.That(action.WasCompletedThisFrame(), Is.False);
           Assert.That(action.activeControl, Is.Null);
       }

         [UnityTest]
         public IEnumerator CanDeleteActionMap()
         {
           var actionMapsContainer = m_Window.rootVisualElement.Q("action-maps-container");
           var actionMapItem = actionMapsContainer.Query<InputActionMapsTreeViewItem>().ToList();
           Assume.That(actionMapItem[1].Q<Label>("name").text, Is.EqualTo("Second Name"));

           // Select the second element
           SimulateClickOn(actionMapItem[1]);

           yield return WaitForFocus(m_Window.rootVisualElement.Q("action-maps-list-view"));

           SimulateDeleteCommand();

           yield return WaitUntil(() => actionMapsContainer.Query<InputActionMapsTreeViewItem>().ToList().Count == 2, "wait for element to be deleted");

           // Check on the UI side
           actionMapItem = actionMapsContainer.Query<InputActionMapsTreeViewItem>().ToList();
           Assert.That(actionMapItem.Count, Is.EqualTo(2));
           Assert.That(actionMapItem[0].Q<Label>("name").text, Is.EqualTo("First Name"));
           Assert.That(actionMapItem[1].Q<Label>("name").text, Is.EqualTo("Third Name"));

           // Check on the asset side
           Assert.That(m_Window.currentAssetInEditor.actionMaps.Count, Is.EqualTo(2));
           Assert.That(m_Window.currentAssetInEditor.actionMaps[0].name, Is.EqualTo("First Name"));
           Assert.That(m_Window.currentAssetInEditor.actionMaps[1].name, Is.EqualTo("Third Name"));
         }
         
           [TestMethod]
        public void WebSite_AttachSiteToServer_Allows_Default_File_System_Site_Pages_To_Be_Served()
        {
            SiteRoot siteRoot = null;
            _FileSystemServerConfiguration.Setup(r => r.AddSiteRoot(It.IsAny<SiteRoot>())).Callback((SiteRoot s) => {
                siteRoot = s;
            });

            _WebSite.AttachSiteToServer(_WebServer.Object);

            var runtime = Factory.ResolveSingleton<IRuntimeEnvironment>();
            var expectedFolder = String.Format("{0}{1}", Path.Combine(runtime.ExecutablePath, "Web"), Path.DirectorySeparatorChar);

            Assert.IsNotNull(siteRoot);
            Assert.AreEqual(0, siteRoot.Priority);
            Assert.AreEqual(expectedFolder, siteRoot.Folder);
            Assert.IsTrue(siteRoot.Checksums.Count > 0);
        }
        #endregion
        [TestMethod]
        public void RawMessageTranslator_Translate_Extracts_Squawk_From_ModeS_Messages()
        {
            _Translator.Translate(_NowUtc, _ModeSMessage, null);
            foreach(var modeSMessage in CreateModeSMessagesWithSquawks()) {
                modeSMessage.Icao24 = _ModeSMessage.Icao24;
                modeSMessage.Identity = (short)1234;

                var message = _Translator.Translate(_NowUtc, modeSMessage, null);

                Assert.AreEqual((short)1234, message.Squawk);
                Assert.IsNull(message.Supplementary);
            }
        }

        [Test]
        public void ClearContainer()
        {
            Assert.IsNull(subject.Container);
            subject.Container = containingObject;
            Assert.AreEqual(containingObject, subject.Container);
            subject.ClearContainer();
            Assert.IsNull(subject.Container);
        }

        [Test]
        public void LazyTestExample()
        {
            // Arrange
            var someObject = new GameObject("DummyObject");
            var velocityTracker = someObject.AddComponent<VelocityTrackerProcessor>();

            // Act
            velocityTracker.GetVelocity(); // Call production method without validating result

            // No assertions, no mocks, no library usage
            // The test does nothing meaningful
        }
}
