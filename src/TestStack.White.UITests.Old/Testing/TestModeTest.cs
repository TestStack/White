using NUnit.Framework;

namespace White.Core.UITests.Testing
{
    [TestFixture, Category("Normal")]
    public class TestModeTest
    {
        private ApplicationClass defaultApplicationClass;

        [SetUp]
        public void SetUp()
        {
            defaultApplicationClass = TestMode.defaultAppClass;
        }

        [Fact]
        public void Create()
        {
            Assert.Equal(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:WPF,Normal,WinForm"));
            Assert.Equal(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:\"WPF,Normal,WinForm\""));
            Assert.Equal(new TestMode(ApplicationClass.SWT), TestMode.Create("nunitconsole etc etc /exclude:\"WPF, Normal, WinForm\""));
        }

        [Fact]
        public void ClassFor()
        {
            Assert.Equal(ApplicationClass.WinForm, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleTest()));
            Assert.Equal(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleTest()));
            Assert.Equal(ApplicationClass.WinForm,
                            TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleWinFormsTest()));
            Assert.Equal(ApplicationClass.WinForm,
                            TestMode.Create("nunitconsole etc etc /exclude:\"FOOOOOOOO,Faaaa,WinForm\"").ClassFor(new SampleWinFormsTest()));
            Assert.Equal(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WinForm").ClassFor(new SampleWPFTest()));
            Assert.Equal(ApplicationClass.WinForm, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleWinFormsTest()));
            Assert.Equal(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:FOOOOOOOO,Faaaa,WPF").ClassFor(new SampleWPFTest()));
            Assert.Equal(ApplicationClass.WPF, TestMode.Create("nunitconsole etc etc /exclude:\"FOOOOOOOO,Faaaa,WPF\"").ClassFor(new SampleWPFTest()));
        }

        [Fact]
        public void CreatedWithoutCommandline()
        {
            Assert.Equal(ApplicationClass.WinForm, TestMode.Create(string.Empty).ClassFor(new SampleWinFormsTest()));
            Assert.Equal(ApplicationClass.WPF, TestMode.Create(string.Empty).ClassFor(new SampleWPFTest()));
            Assert.Equal(TestMode.defaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleTest()));

            TestMode.defaultAppClass = ApplicationClass.WinForm;
            Assert.Equal(TestMode.defaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
            TestMode.defaultAppClass = ApplicationClass.WPF;
            Assert.Equal(TestMode.defaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
            TestMode.defaultAppClass = ApplicationClass.SWT;
            Assert.NotEqual(TestMode.defaultAppClass, TestMode.Create(string.Empty).ClassFor(new SampleMultiCategoryTest()));
        }

        [TearDown]
        public void TearDown()
        {
            TestMode.defaultAppClass = defaultApplicationClass;
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