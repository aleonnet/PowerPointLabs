﻿using PowerPointLabs.ActionFramework.Common.Attribute;
using PowerPointLabs.ActionFramework.Common.Interface;

namespace PowerPointLabs.ActionFramework.Label.PasteLab
{
    [ExportLabelRibbonId(
        "PasteToFillSlide",
        "PasteToFillSlideShape",
        "PasteToFillSlideFreeform",
        "PasteToFillSlidePicture",
        "PasteToFillSlideGroup")]
    class PasteToFillSlideLabelHandler : LabelHandler
    {
        protected override string GetLabel(string ribbonId)
        {
            return TextCollection.PasteLabText.PasteToFillSlide;
        }
    }
}