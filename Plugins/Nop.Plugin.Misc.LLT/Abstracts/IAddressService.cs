using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Abstracts
{
    public interface IAddressService
    {
        void Add(Address address);
        void Update(Address address);
        void Delete(Address address);

        Address GetById(int addressId);
    }
}
