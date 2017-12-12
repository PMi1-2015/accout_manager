using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace AccountSystem
{
    class ErrorLabel : Label
    {
        protected override void OnContentChanged(object oldContent, object newContent)
        {
            base.OnContentChanged(oldContent, newContent);
            ChangeAppearence();
        }

        private void ChangeAppearence()
        {
            double to = Visibility == Visibility.Visible ? 0.0 : 1.0;
            double from = Visibility == Visibility.Visible ? 1.0 : 0.0;
            Visibility newState = Visibility == Visibility.Visible ? Visibility.Hidden : Visibility.Visible;
            double beginTime = Visibility == Visibility.Visible ? 2 : 0;

            var disapppearAnimation = new DoubleAnimation
            {
                From = to,
                To = from,
                FillBehavior = FillBehavior.Stop,
                BeginTime = TimeSpan.FromSeconds(beginTime),
                Duration = new Duration(TimeSpan.FromSeconds(0.1))
            };

            var storyBoard = new Storyboard();

            storyBoard.Children.Add(disapppearAnimation);
            storyBoard.Completed += (o, e) =>
            {
                Visibility = newState;
                Content = "";
            };

            Storyboard.SetTarget(disapppearAnimation, this);
            Storyboard.SetTargetProperty(disapppearAnimation, new PropertyPath(OpacityProperty));

            storyBoard.Begin();
        }
    }
}
