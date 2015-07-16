using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;


namespace FarmExp.Data.EntityFramework
{
   public class FarmEntityConfiguration<T>:EntityTypeConfiguration<T>where T:class
    {
       protected  FarmEntityConfiguration()
       {
           PostInitialize();
       }
       protected virtual void PostInitialize()
       {

       }
    }
}
