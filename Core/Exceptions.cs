using Api.Errors.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Core
{
    public abstract class PayloadException : ApplicationException
    {
        public abstract ErrorCode ErrorCode { get; }
        protected PayloadException(string message, Exception? inner = null) : base(message, inner) { }

        [ExcludeFromCodeCoverage]
        protected PayloadException(SerializationInfo info, StreamingContext context)
            : base(info, context) { }

        [Serializable]
        public sealed class PayloadNotValidatedException : PayloadException
        {
            public PayloadNotValidatedException(Guid ticketId)
                : base($"The validation for given ticket Id '{ticketId}' was not produced")
            {
            }

            [ExcludeFromCodeCoverage]
            private PayloadNotValidatedException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }

            public override ErrorCode ErrorCode { get; } = ErrorCode.PayloadNotValidated;
        }

        [Serializable]
        public sealed class PayloadValidationFailedException : PayloadException
        {
            public PayloadValidationFailedException(Guid ticketId)
                : base($"The validation for given ticket Id '{ticketId}' failed")
            {
            }

            [ExcludeFromCodeCoverage]
            private PayloadValidationFailedException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }

            public override ErrorCode ErrorCode { get; } = ErrorCode.PayloadValidationFailed;
        }

        [Serializable]
        public sealed class PayloadSourceAlreadySentException : PayloadException
        {
            public PayloadSourceAlreadySentException(Guid ticketId)
                : base($"The payload operation with Id '{ticketId}' has already been sent.")
            {
            }

            [ExcludeFromCodeCoverage]
            private PayloadSourceAlreadySentException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }

            public override ErrorCode ErrorCode { get; } = ErrorCode.PayloadOperationAlreadyAcknowledged;
        }

        [Serializable]
        public sealed class PayloadNotConfirmedException : PayloadException
        {
            public PayloadNotConfirmedException(Guid ticketId)
                : base($"The payload with Id '{ticketId}' has not been confirmed")
            {
            }

            [ExcludeFromCodeCoverage]
            private PayloadNotConfirmedException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }

            public override ErrorCode ErrorCode { get; } = ErrorCode.PayloadOperationNotInitialized;
        }

        [Serializable]
        public sealed class PayloadOperationAlreadyAcknowledgedException : PayloadException
        {
            public PayloadOperationAlreadyAcknowledgedException(Guid ticketId)
                : base($"The payload operation with Id '{ticketId}' has already been acknowledged.")
            {
            }

            [ExcludeFromCodeCoverage]
            private PayloadOperationAlreadyAcknowledgedException(SerializationInfo info, StreamingContext context)
                : base(info, context) { }

            public override ErrorCode ErrorCode { get; } = ErrorCode.PayloadOperationAlreadyAcknowledged;
        }
    }
}
