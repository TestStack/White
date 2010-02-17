namespace White.CustomControls.Automation
{
    public interface ICustomCommandDeserializer
    {
        ICustomCommand GetCommand(string @string);
    }
}