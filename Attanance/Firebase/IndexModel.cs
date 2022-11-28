using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Attanance.Firebase
{
    public class IndexModel
    {
        private IHostingEnvironment env;
        public string result;
        public IndexModel(IHostingEnvironment env)
        {
            this.env = env;
        }

        public async Task OnGetAsync()
        {
            var path = env.ContentRootPath;
            path = path + "\\Auth.json";
            FirebaseApp app = null;
            try
            {
                app = FirebaseApp.Create(new AppOptions()
                {
                    Credential = GoogleCredential.FromFile(path)
                }, "myApp");
            }
            catch (Exception ex)
            {
                app = FirebaseApp.GetInstance("myApp");
            }

            var fcm = FirebaseAdmin.Messaging.FirebaseMessaging.GetMessaging(app);
            Message message = new Message()
            {
                Notification = new Notification
                {
                    Title = "My push notification title",
                    Body = "Content for this push notification"
                },
                Data = new Dictionary<string, string>()
                 {
                     { "AdditionalData1", "data 1" },
                     { "AdditionalData2", "data 2" },
                     { "AdditionalData3", "data 3" },
                 },

                Topic = "WebsiteUpdates"
            };

            this.result = await fcm.SendAsync(message);


        }


    }
}
