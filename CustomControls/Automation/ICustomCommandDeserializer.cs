namespace White.WPFCustomControls.Automation
{
    public interface ICustomCommandDeserializer
    {
        ICustomCommand GetCommand(string @string);
    }
}