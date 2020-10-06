using AbstractHotelBusinessLogic.Interfaces;
using AbstractHotelDatabaseImplement.Implements;
using System;
using System.Configuration;
using System.Threading;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;
namespace AbstractHotel
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<ILunchLogic, LunchLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRoomLogic, RoomLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IRequestLogic, RequestLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
