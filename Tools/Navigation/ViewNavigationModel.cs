﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BD_oneLove.Views.UsersViews;

namespace BD_oneLove.Tools.Navigation
{
    internal class ViewNavigationModel : BaseNavigationModel
    {
        public ViewNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.MyClassView:
                    ViewsDictionary.Add(viewType, new MyClassView());
                    break;
                case ViewType.TeachersView:
                   ViewsDictionary.Add(viewType, new TeachersView());
                   break;
                case ViewType.ParentsView:
                    ViewsDictionary.Add(viewType, new ParentsView());
                    break;
                case ViewType.UsersView:
                    ViewsDictionary.Add(viewType, new UsersView());
                    break;
                case ViewType.PutMarksView:
                    ViewsDictionary.Add(viewType, new PutMarksView());
                    break;
                case ViewType.SocialPassportView:
                    ViewsDictionary.Add(viewType, new SocialPassportView());
                    break;
                //case ViewType.EditPersonView:
                //    ViewsDictionary.Add(viewType, new EditPersonView());
                //    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
