﻿using FluentValidation;
using RCM.API.Models.Calls;

namespace RCM.API.Validators.Calls
{
    public class StreamStatusCallbackValidator : AbstractValidator<StreamStatusCallback>
    {
        public StreamStatusCallbackValidator()
        {

        }
    }
}