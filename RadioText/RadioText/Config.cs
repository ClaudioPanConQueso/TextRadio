using Exiled.API.Interfaces;

namespace RadioText
{
    public sealed class Config : IConfig
    {
        public bool IsEnabled { get; set; } = true;
    }
}