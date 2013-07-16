namespace WindowsFormsTestApplication
{
    public class ComplexNumber
    {
        public ComplexNumber(int real, int imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public ComplexNumber() { }

        public int Real { get; set; }
        public int Imaginary { get; set; }
    }
}