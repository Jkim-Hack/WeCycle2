using System;
using System.Collections.Generic;
using System.Text;

namespace WeCycle
{
    public interface IDeviceCaptureImage
    {
        void OnCameraPreviewClick(object sender, EventArgs e);
    }
}
