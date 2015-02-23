using System;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace ReportingDesigner.Extensibility.Events
{
    public interface ICommandBus
    {
        void AddHandler<TCommand>(Action<TCommand> handler) where TCommand : ICommand;
        void Post<TCommand>(TCommand command) where TCommand : ICommand;
        void RemoveHandler<TCommand>(Action<TCommand> handler) where TCommand:ICommand;
    }
}
