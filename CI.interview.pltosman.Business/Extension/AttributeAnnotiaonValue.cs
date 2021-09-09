﻿using System;
using System.Linq;

namespace CI.interview.pltosman.Business.Extension
{
    public static class AttributeAnnotiaonValue
    {
        public static T GetAttributeFrom<T>(this object instance, string propertyName) where T : Attribute
        {
            var attrType = typeof(T);
            var property = instance.GetType().GetProperty(propertyName);
            return (T)property.GetCustomAttributes(attrType, false).First();
        }
    }
}
