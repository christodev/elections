using System;
namespace Elections.Models.UserCommandPattern
{
    public interface IUserCommand
    {
        void Execute();
    }
}
