using NUnit.Framework;

namespace White.Core.Testing
{
    [TestFixture, Category("Normal")]
    public class TestModeTest
    {
        private ApplicationClass defaultApplicationClass;

        [SetUp]
        public void SetUp()
        {
            defaultApplicationClass = TestMode.DefaultAppClass;
        }

        [Test]
        public void Create()
        {
            Assert.AreEqual(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:WPF,Normal,WinForm"));
            Assert.AreEqual(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:\"WPF,Normal,WinForm\""));
            Assert.AreEqual(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:\"WPF, Normal, WinForm\""));
        }

        [Test]
        public void ClassFor()
        {
            Assert.AreEqual(ApplicationClass.WinForm, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleTest()));
            Assert.AreEqual(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleTest()));
            Assert.AreEqual(ApplicationClass.WinForm,
                            TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleWinFormsTest()));
            Assert.AreEqual(ApplicationClass.WinForm,
                            TestMode.Create("nunitconsole etc etc /exclude:\"FOOOOOOOO,Faaaa,WinForm\"").ClassFor(new SampleWinFormsTest()));
            Assert.AreEqual(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleWPFTest()));
            Assert.AreEqual(ApplicationClass.WinForm, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleWinFormsTest()));
            Assert.AreEqual(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleWPFTest()));
            Assert.AreEqual(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:\"FOOOOOOOO,Faaaa,WPF\"").ClassFor(new SampleWPFTest()));
        }

        [Test]
        public void CreatedWithoutCommandline()
        {
            Assert.AreEqual(ApplicationClass.WinForm, TestMode.Create(string.Empty).ClassFor(new SampleWinFormsTest()));
            Assert.AreEqual(ApplicationClass.WPF, TestMode.Create(string.Empty).ClassFor(new SampleWPFTest()));
            Assert.AreEqual(TestMode.DefaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleTest()));

            TestMode.DefaultAppClass = ApplicationClass.WinForm;
            Assert.AreEqual(TestMode.DefaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
            TestMode.DefaultAppClass = ApplicationClass.WPF;
            Assert.AreEqual(TestMode.DefaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
            TestMode.DefaultAppClass = ApplicationClass.SWT;
            Assert.AreNotEqual(TestMode.DefaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
        }

        [TearDown]
        public void TearDown()
        {
            TestMode.DefaultAppClass = defaultApplicationClass;
        }
    }

    [WinFormCategory]
    public class SampleWinFormsTest {}

    [WPFCategory]
    public class SampleWPFTest {}

    public class SampleTest {}

    [WinFormCategory, WPFCategory]
    public class SampleMultiCategoryTest {}
}