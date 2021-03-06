﻿using System.Linq;
using AutoMapper.Extensions.EnumMapping.Internal;

namespace AutoMapper.Extensions.EnumMapping
{
    /// <summary>
    /// Extension class to support validation for EnumMappings
    /// </summary>
    public static class EnumMapperConfigurationExpressionExtensions
    {
        /// <summary>
        /// Enable EnumMapping configuration validation
        /// </summary>
        /// <param name="mapperConfigurationExpression">Configuration object for AutoMapper</param>
        public static void EnableEnumMappingValidation(this IMapperConfigurationExpression mapperConfigurationExpression)
        {
            mapperConfigurationExpression.Advanced.Validator(context =>
            {
                if (context.TypeMap != null)
                {
                    var validator = context.TypeMap.Features.OfType<IEnumMappingValidationRuntimeFeature>().SingleOrDefault();
                    validator?.Validate(context.TypeMap.Types);
                }
            });
        }
    }
}
