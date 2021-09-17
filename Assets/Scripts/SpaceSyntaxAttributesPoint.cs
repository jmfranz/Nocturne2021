/* Author: Jake Moore
 * This script is used solely as a data container for an object I have defined as an SpaceSyntaxAttributesPoint.  
 
 
 TODO: UPDATE THIS -> An rgbPoint is defined as its position in the texture array [width,height] 
 * and its r, g, and b values.  This data container is used in the linearSort script in order to easier pass and compare pixel values.
 */

public class SpaceSyntaxAttributesPoint {
    private float width, height, value, r, g, b, openness, visualComplexity, visualIntegration;

    public SpaceSyntaxAttributesPoint()
    {

    }

    public SpaceSyntaxAttributesPoint (int width, int height, float openness, float visualComplexity, float visualIntegration) {
        this.width = (float) width;
        this.height = (float) height;

        // TODO: Remove these
        this.r = openness;
        this.g = visualComplexity;
        this.b = visualIntegration;
        // -- End todo

        this.openness = openness;
        this.visualComplexity = visualComplexity;
        this.visualIntegration = visualIntegration;

    }

    public void setWidth (float width) {
        this.width = width;
    }
    public void setHeight (float height) {
        this.height = height;
    }
    public void setValue (float value) {
        this.value = value;
    }

    // Used for contour maps
    /*
    public void setR (int r) {
        this.r = r;
    }
    public void setG (int g) {
        this.g = g;
    }
    public void setB (int b) {
        this.b = b;
    } */

    public void setOpenness (int openness) {
        this.openness = openness;
    }

    public void setVisualComplexity (int vc) {
        this.visualComplexity = vc;
    }

    public void setVisualIntegration (int vi) {
        this.visualIntegration = vi;
    }

    public float getWidth () {
        return width;
    }
    public float getHeight () {
        return height;
    }
    public float getValue () {
        return value;
    }
    public float getR () {
        return r;
    }
    public float getG () {
        return g;
    }
    public float getB () {
        return b;
    }

    public float getOpenness () {
        return openness;
    }

    public float getVisualIntegration () {
        return visualIntegration;
    }

    public float getVisualComplexity () {
        return visualComplexity;
    }

    //Equals function that compares width and height.
    public override bool Equals (object obj) {
        if (obj.GetType () != this.GetType ()) {
            return false;
        }
        SpaceSyntaxAttributesPoint other = (SpaceSyntaxAttributesPoint) obj;
        return this.width == other.width && this.height == other.height;
    }

    //public override int GetHashCode () {
    //    return width ^ height;
    //}
}
