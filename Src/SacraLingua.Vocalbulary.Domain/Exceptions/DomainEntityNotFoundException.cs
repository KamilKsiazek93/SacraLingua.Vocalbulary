namespace SacraLingua.Vocalbulary.Domain.Exceptions
{
    public class DomainEntityNotFoundException : Exception
    {
        public DomainEntityNotFoundException(string type, object id) : 
            base($"Can not find {type} with id {id}") { }
    }
}
