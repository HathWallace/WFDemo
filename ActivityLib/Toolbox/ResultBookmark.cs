using System;
using System.Activities;

namespace ActivityLib.Toolbox
{
    public sealed class ResultBookmark<T> : NativeActivity<T>
    {
        public InArgument<string> BookmarkName { get; set; }

        protected override bool CanInduceIdle => true;

        protected override void Execute(NativeActivityContext context)
        {
            string bookmark = context.GetValue(BookmarkName);
            context.CreateBookmark(bookmark, BookmarkCallback);
            //Console.WriteLine("创建bookmark:{0}", bookmark);
        }

        private void BookmarkCallback(NativeActivityContext context, Bookmark bookmark, object obj)
        {
            this.Result.Set(context, (T)obj);
        }

    }
}