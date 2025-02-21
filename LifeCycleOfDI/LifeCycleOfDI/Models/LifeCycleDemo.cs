namespace LifeCycleOfDI.Models
{
    public interface ISingleton
    {
        Guid Value { get; }

    }

    public interface IScoped
    {
        Guid Value { get; }
    }

    public interface ITransient
    {
        Guid Value { get; }
    }

    public class Singleton : ISingleton
    {
        public Guid Value { get; private set; }
        private readonly ILogger<Singleton> _logger;


        public Singleton(ILogger<Singleton> logger)
        {
            _logger = logger;
            Value = Guid.NewGuid();
            _logger.LogInformation($"Singleton Created at {DateTime.Now}, Guid value: {Value} ");

        }
    }

    public class Scoped : IScoped
    {
        public Guid Value { get; private set; }
        private readonly ILogger<Scoped> _logger;
        public Scoped(ILogger<Scoped> logger)
        {
            _logger = logger;
            Value = Guid.NewGuid();
            _logger.LogInformation($"Scoped Created at {DateTime.Now}, Guid value: {Value} ");
        }
    }

    public class Transient : ITransient
    {
        private readonly ILogger<Transient> _logger;
        public Guid Value { get; private set; }
        public Transient(ILogger<Transient> logger)
        {
            _logger = logger;
            Value = Guid.NewGuid();
            _logger.LogInformation($"Transient Created at {DateTime.Now}, Guid value: {Value} ");
        }
    }

    public class  CustomService
    {
        public CustomService(ISingleton singleton, ITransient transient, IScoped scoped)
        {
            Singleton = singleton;
            Transient = transient;
            Scoped = scoped;
        }

        public ISingleton Singleton { get; }
        public ITransient Transient { get; }
        public IScoped Scoped { get; }
    }
}
