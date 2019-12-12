using module1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace module1.ViewModels
{
    public class CommentViewModel : ViewModelBase<Commentaire>
    {
        public CommentViewModel()
        {
            this.ShowActionLinks = false;
        }
    }
}