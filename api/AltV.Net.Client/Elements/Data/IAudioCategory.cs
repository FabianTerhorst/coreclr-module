namespace AltV.Net.Client.Elements.Data;

public interface IAudioCategory
{
    float Volume{ get; set; }
    float DistanceRolloffScale{ get; set; }
    float PlateauRolloffScale{ get; set; }
    float OcclusionDamping{ get; set; }
    float EnvironmentalFilterDamping{ get; set; }
    float SourceReverbDamping{ get; set; }
    float DistanceReverbDamping{ get; set; }
    float InteriorReverbDamping{ get; set; }
    float EnvironmentalLoudness{ get; set; }
    float UnderwaterWetLevel{ get; set; }
    float StonedWetLevel{ get; set; }
    short Pitch{ get; set; }
    short LowPassFilterCutoff{ get; set; }
    short HighPassFilterCutoff{ get; set; }

    void Reset();
}