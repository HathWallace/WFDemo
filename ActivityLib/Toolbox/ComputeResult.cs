using System.Activities;
using System.Collections.Generic;

namespace ActivityLib.Toolbox
{
    public class ComputeResult : CodeActivity
    {
        public InArgument<List<bool>> ResultList { get; set; }

        public OutArgument<bool> Pass { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            int result = 0;
            var resultList = context.GetValue(ResultList);
            foreach (var res in resultList)
            {
                result += res ? 1 : -1;
            }

            context.SetValue(Pass, result > 0);
        }

    }
}