using NameCrackerAPI.Models;

namespace NameCrackerAPI.Interfaces
{
    public interface IStringParserService
    {
        ParsedString ParseFullString(string fullString);
    }
}

