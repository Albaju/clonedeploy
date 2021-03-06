﻿using System;
using CloneDeploy_Common;
using CloneDeploy_Web.BasePages;

namespace CloneDeploy_Web.views.images.profiles
{
    public partial class views_images_profiles_Default : Images
    {
        protected void buttonUpdateMulticast_OnClick(object sender, EventArgs e)
        {
            RequiresAuthorizationOrManagedImage(AuthorizationStrings.UpdateProfile, Image.Id);
            ImageProfile.SenderArguments = txtSender.Text;
            ImageProfile.ReceiverArguments = txtReceiver.Text;
            var result = Call.ImageProfileApi.Put(ImageProfile.Id, ImageProfile);
            EndUserMessage = result.Success ? "Successfully Updated Image Profile" : result.ErrorMessage;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                txtSender.Text = ImageProfile.SenderArguments;
                txtReceiver.Text = ImageProfile.ReceiverArguments;
            }
        }
    }
}