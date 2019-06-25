using GalaSoft.MvvmLight.Views;
using GameChange.ViewModels;
using GameChange.Views;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using static GameChange.ViewModels.ViewModelLocator;

namespace GameChange.Services
{
    public class NavigationService : INavigationService
    {
        private readonly Dictionary<string, Type> _pagesByKey = new Dictionary<string, Type>();
        private Dictionary<string, CustomNavigateEvents> _customNavEvents = new Dictionary<string, CustomNavigateEvents>();
        private NavigationPage _navigation = new NavigationPage();
        private Stack<string> _currPageKey = new Stack<string>();
        private static NavigationService navigationService = null;
        public string CurrentPageKey
        {
            get
            {
                if (_currPageKey.Count >= 0)
                    return _currPageKey.Peek();
                else
                    return null;
            }
        }
        private NavigationService()
        {
            ConfigureViews();
        }
        public void ConfigureViews()
        {
            Configure(NavigatePage.HomeView.ToString(), typeof(MainPage));
            Configure(NavigatePage.CreateView.ToString(), typeof(CreatePageView));
            Configure(NavigatePage.ListView.ToString(), typeof(ListPageView));
        }
        public static NavigationService GetNavigationService
        {
            get
            {
                if (navigationService == null)
                    navigationService = new NavigationService();
                return navigationService;
            }
        }

        public CustomNavigateEvents CustomNavEvent
        {
            get
            {
                return _customNavEvents[_currPageKey.Peek()];
            }
        }


        public void GoBack()
        {
            if (CanGoBack())
            {
                _customNavEvents[_currPageKey.Pop()].GoBackEvent();
                _navigation.PopAsync();
            }
        }

        public bool CanGoBack()
        {
            bool canGoBack = false;
            if (_navigation.Navigation.NavigationStack.Count > 0) canGoBack = true;
            return canGoBack;
        }

        public bool HasPages()
        {
            if (_currPageKey.Count > 0)
                return true;
            else
                return false;
        }

        public void NavigateTo(string pageKey)
        {
            NavigateTo(pageKey, null);
        }

        public void InsertPageBefore(string pageKey, object parameter, string pageKeyBefore)
        {
            Page pageBefore = null;
            _currPageKey.Push(pageKey);
            if (!_customNavEvents.ContainsKey(pageKey))
            {
                _customNavEvents.Add(pageKey, new CustomNavigateEvents());
            }
            var type = _pagesByKey[pageKey];
            if (type != null)
            {
                Page page = (Page)Activator.CreateInstance(type);
                Application.Current.MainPage = _navigation;
                foreach (Page p in _navigation.Navigation.NavigationStack)
                {
                    if (p.GetType().Equals(_pagesByKey[pageKeyBefore]))
                    {
                        pageBefore = p;
                        break;
                    }
                }
                _navigation.Navigation.InsertPageBefore(page, pageBefore);
            }
            else return;
        }

        public void NavigateTo(string pageKey, object parameter)
        {
            _currPageKey.Push(pageKey);
            if (!_customNavEvents.ContainsKey(pageKey))
            {
                _customNavEvents.Add(pageKey, new CustomNavigateEvents());
            }
            var type = _pagesByKey[pageKey];
            Page page = (Page)Activator.CreateInstance(type);
            Application.Current.MainPage = _navigation;

            _navigation.PushAsync(page);
        }

        public void Configure(string pageKey, Type pageType)
        {
            lock (_pagesByKey)
            {
                if (_pagesByKey.ContainsKey(pageKey))
                    _pagesByKey[pageKey] = pageType;

                else
                    _pagesByKey.Add(pageKey, pageType);
            }
        }
        public void Initialize(NavigationPage navigation)
        {
            _navigation = navigation;
            Application.Current.MainPage = _navigation;
        }
    }
    public class CustomNavigateEvents
    {
        public delegate void GoBackEventHandler();
        public event GoBackEventHandler OnGoBack;

        public void GoBackEvent()
        {
            OnGoBack?.Invoke();
        }
    }
}