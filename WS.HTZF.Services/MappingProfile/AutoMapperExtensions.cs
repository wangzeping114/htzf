using AutoMapper;
using System;
using System.ComponentModel;

namespace WS.HTZF.Application.MappingProfile
{
    /// <summary>
    /// 创建一个扩展类，它将忽略将用NoMap属性修饰的属性
    /// </summary>
    public static class AutoMapperExtensions
    {
        /// <summary>
        /// 此扩展方法是根据NoMap特性现在有条件性的来映射属性
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TDestination"></typeparam>
        /// <param name="expression"></param>
        /// <returns></returns>
        public static IMappingExpression<TSource, TDestination> IgnoreNoMap<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> expression) 
        {
            var sourceType = typeof(TSource);
            foreach (var property in sourceType.GetProperties())
            {
                PropertyDescriptor descriptor = TypeDescriptor.GetProperties(sourceType)[property.Name];
                NoMapAttribute attribute = (NoMapAttribute)descriptor.Attributes[typeof(NoMapAttribute)];
                if (attribute != null) 
                {
                    expression.ForMember(property.Name, opt => opt.Ignore());
                }
                
            }
            return expression;
        }

        /// <summary>
        /// 此扩展方法是判断属性为Null时不进行属性映射
        /// </summary>
        /// <param name="cfg"></param>
        public static void IgnoreSourceWhenNull(this IMapperConfigurationExpression cfg)
        {
            cfg.ForAllPropertyMaps(pm =>
            {
                if (pm.SourceMember != null && (pm.DestinationMember.Name != pm.SourceMember.Name))
                    return false;
                if (pm.SourceType == null)
                    return false;
                var isNullable = pm.SourceType.IsGenericType && (pm.SourceType.GetGenericTypeDefinition() == typeof(Nullable<>));
                return isNullable || pm.SourceType.IsValueType || pm.SourceType.IsPrimitive;
            }, (pm, c) =>
            {
                c.MapFrom<Resolver, object>(pm.SourceMember.Name);
            });

        }
        class Resolver : IMemberValueResolver<object, object, object, object>
        {
            public object Resolve(object source, object destination, object sourceMember, object destinationMember, ResolutionContext context)
            {
                return sourceMember ?? destinationMember;
            }
        }
    }
}
