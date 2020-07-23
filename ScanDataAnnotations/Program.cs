using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ScanEFDataAnnotations
{
    class Program
    {
        static void Main(string[] args)
        {
            Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
            Console.WriteLine("Your model assembly name:");
            var assemblyName = Console.ReadLine();

            var asm = Assembly.Load(assemblyName);
            var classes = asm.GetTypes().Where(p => p.IsClass).ToList();

            foreach (var item in classes)
            {
                // Just grabbing this to get hold of the type name:
                var type = item.GetType();

                // Get the PropertyInfo object:
                var properties = item.GetProperties();

                if (HasEFDataAnnotaion(properties))
                {
                    Console.WriteLine("");
                    Console.WriteLine("Found Data Annotations attributes at {0} ...", item.FullName);
                    foreach (var property in properties)
                    {
                        var attributes = property.GetCustomAttributes(false);

                        // Using reflection.  
                        Attribute[] attrs = System.Attribute.GetCustomAttributes(property);

                        // Displaying output.  
                        foreach (Attribute attr in attrs)
                        {

                            if (attr is KeyAttribute)
                            {
                                KeyAttribute a = (KeyAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is ForeignKeyAttribute)
                            {
                                ForeignKeyAttribute a = (ForeignKeyAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is IndexAttribute)
                            {
                                IndexAttribute a = (IndexAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.GetType().FullName + a.ToString(), property.Name);
                            }

                            if (attr is RequiredAttribute)
                            {
                                RequiredAttribute a = (RequiredAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is TimestampAttribute)
                            {
                                TimestampAttribute a = (TimestampAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is ConcurrencyCheckAttribute)
                            {
                                ConcurrencyCheckAttribute a = (ConcurrencyCheckAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is MinLengthAttribute)
                            {
                                MinLengthAttribute a = (MinLengthAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is MaxLengthAttribute)
                            {
                                MaxLengthAttribute a = (MaxLengthAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is StringLengthAttribute)
                            {
                                StringLengthAttribute a = (StringLengthAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is TableAttribute)
                            {
                                TableAttribute a = (TableAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is ColumnAttribute)
                            {
                                ColumnAttribute a = (ColumnAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is DatabaseGeneratedAttribute)
                            {
                                DatabaseGeneratedAttribute a = (DatabaseGeneratedAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }

                            if (attr is ComplexTypeAttribute)
                            {
                                ComplexTypeAttribute a = (ComplexTypeAttribute)attr;
                                Console.WriteLine("attribute {0} on {1} ", a.ToString(), property.Name);
                            }
                        }
                    }
                }
            }
        }

        private static bool HasEFDataAnnotaion(PropertyInfo[] properties)
        {
            return properties.ToList().Any((property) =>
            {
                var attributes = property.GetCustomAttributes(false);
                Attribute[] attrs = System.Attribute.GetCustomAttributes(property);
                return attrs.Any((attr) =>
                {
                    return attr is KeyAttribute || attr is ForeignKeyAttribute || attr is IndexAttribute || attr is RequiredAttribute || attr is TimestampAttribute
                    || attr is ConcurrencyCheckAttribute || attr is MinLengthAttribute || attr is MinLengthAttribute
                    || attr is MaxLengthAttribute || attr is StringLengthAttribute || attr is TableAttribute || attr is ColumnAttribute
                    || attr is DatabaseGeneratedAttribute || attr is ComplexTypeAttribute;
                });
            });
        }
    }
}
