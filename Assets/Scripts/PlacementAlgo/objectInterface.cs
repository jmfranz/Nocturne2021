public interface Iobject 
{
    void setID(string id);
    void setType(string type);
    void setPriority(string priority);
    void setCardinality(string cardinality);
    void setOpenness(string openness);
    void setPrecision(string precision);
    string getID();
    string getType();
    string getPriority();
    string getCardinality();
    string getOpenness();
    string getPrecision();
}
