namespace NukeProxyObjCRuntimeRegistrar;

public sealed class MainViewController : UIViewController
{
    private UIImageView? _image;

    public override void LoadView()
    {
        base.LoadView();

        View.BackgroundColor = UIColor.White;

        var label = new UILabel
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            Text = "Hello Nuke",
            TextAlignment = UITextAlignment.Center,
            TextColor = UIColor.Black
        };

        Add(label);

        label.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor).Active = true;
        label.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor).Active = true;
        label.TopAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TopAnchor, 40).Active = true;


        _image = new UIImageView
        {
            TranslatesAutoresizingMaskIntoConstraints = false,
            ContentMode = UIViewContentMode.ScaleAspectFit,
            BackgroundColor = UIColor.Gray
        };

        Add(_image);

        _image.LeadingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.LeadingAnchor, 16).Active = true;
        _image.TrailingAnchor.ConstraintEqualTo(View.SafeAreaLayoutGuide.TrailingAnchor, -16).Active = true;
        _image.TopAnchor.ConstraintEqualTo(label.BottomAnchor, 16).Active = true;
    }

    public override void ViewDidAppear(bool animated)
    {
        base.ViewDidAppear(animated);

        if (_image != null)
            ImageCaching.Nuke.ImagePipeline.Shared.LoadImageWithUrl(
                new NSUrl("https://picsum.photos/200/300"),
                null,
                null,
                _image);
    }
}
