using Nop.Core.Data;
using Nop.Plugin.Misc.LLT.Abstracts;
using Nop.Plugin.Misc.LLT.Domain;

namespace Nop.Plugin.Misc.LLT.Service
{
    public class AddressService : IAddressService
    {
        private readonly IRepository<Address> _addressRepository;

        public AddressService(IRepository<Address> addressRepository)
        {
            _addressRepository = addressRepository;
        }

        public void Add(Address address)
        {
           _addressRepository.Insert(address);
        }

        public void Update(Address address)
        {
            _addressRepository.Update(address);
        }

        public void Delete(Address address)
        {
            address.Deleted = true;
            _addressRepository.Update(address);
        }

        public Address GetById(int addressId)
        {
            return _addressRepository.GetById(addressId);
        }
    }
}
