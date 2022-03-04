using Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    internal class PayloadValidationService : IPayloadValidationService
    {
        

        

        public async Task ValidatePayload(Stream payload)
        {
            throw new PayloadSourceNotFoundException("ticketId");
        }

    }
}
