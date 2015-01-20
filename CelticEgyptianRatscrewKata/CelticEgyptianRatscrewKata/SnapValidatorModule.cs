using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Builder;

namespace CelticEgyptianRatscrewKata
{
    public class SnapValidatorModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ConsecutiveRankValidator>().As<IConsecutiveRankValidator>();

            builder.RegisterType<DarkQueenSnapValidator>().As<ISnapValidator>();
            builder.RegisterType<SandwichSnapValidator>().As<ISnapValidator>();
            builder.RegisterType<StandardSnapValidator>().As<ISnapValidator>();
        }
    }
}
