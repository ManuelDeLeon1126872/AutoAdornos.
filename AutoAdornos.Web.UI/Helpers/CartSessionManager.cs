using AutoAdornos.Web.UI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AutoAdornos.Web.UI.Helpers
{
    public static class CartSessionManager
    {
        private const string CartKey = "AUTOADORNOS_WEB_CART";
        private const string UserKey = "AUTOADORNOS_WEB_USER";

        public static List<CartItemViewModel> GetCart(HttpSessionStateBase session)
        {
            if (session[CartKey] == null)
            {
                session[CartKey] = new List<CartItemViewModel>();
            }

            return (List<CartItemViewModel>)session[CartKey];
        }

        public static void SaveCart(HttpSessionStateBase session, List<CartItemViewModel> items)
        {
            session[CartKey] = items;
        }

        public static void AddItem(HttpSessionStateBase session, CartItemViewModel item)
        {
            var cart = GetCart(session);
            var existing = cart.FirstOrDefault(x => x.IdProducto == item.IdProducto);

            if (existing == null)
            {
                cart.Add(item);
            }
            else
            {
                existing.Cantidad += item.Cantidad;
            }

            SaveCart(session, cart);
        }

        public static void RemoveItem(HttpSessionStateBase session, int idProducto)
        {
            var cart = GetCart(session);
            cart.RemoveAll(x => x.IdProducto == idProducto);
            SaveCart(session, cart);
        }

        public static void ClearCart(HttpSessionStateBase session)
        {
            session[CartKey] = new List<CartItemViewModel>();
        }

        public static UserSessionModel GetUser(HttpSessionStateBase session)
        {
            return session[UserKey] as UserSessionModel;
        }

        public static void SaveUser(HttpSessionStateBase session, UserSessionModel user)
        {
            session[UserKey] = user;
        }

        public static void Logout(HttpSessionStateBase session)
        {
            session.Remove(UserKey);
            session.Remove(CartKey);
        }

        public static bool IsAuthenticated(HttpSessionStateBase session)
        {
            var user = GetUser(session);
            return user != null && user.EstaAutenticado;
        }
    }
}
