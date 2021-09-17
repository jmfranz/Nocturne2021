using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;
using ProxemicUIFramework;

namespace TestProximityRules
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    //public partial class MainWindow : Window
    //{
    //    DataReceiver DataReceiver = new DataReceiver(5103, "127.0.0.1");
    //    Task task;
    //    List<string> Entities = new List<string>();
    //    TextBlock textBlock = new TextBlock();
    //    Canvas _canvas = new Canvas();
    //    public MainWindow()
    //    {
    //        InitializeComponent();

    //        this.Content = _canvas;
    //        _canvas.Background = Brushes.Gray;
    //        _canvas.Children.Add(textBlock);
    //        textBlock.FontSize = 25;

    //        if (task == null)
    //        {
    //            task = new Task(new Action(RetriveEntities));
    //            task.Start();
    //        }

    //        CreatRule();
    //    }

    //    void RetriveEntities()
    //    {
    //        while (true)
    //        {
    //            Entities = EntityContainer.EntityRetrievalAll();
    //        }
    //    }

    //    double minimumThrehold, maximumthreshold, threshold;
    //    string testCondition;
    //    void CreatRule()
    //    {

    //        /*// Basic rules that we might need

    //        RelativeDistanceRule relativeDistance = new RelativeDistanceRule(minimumThrehold, maximumthreshold, Entities, Entities, testCondition);

    //        RelativeOrientationRule relativeOrientation = new RelativeOrientationRule(threshold, Entities, Entities, testCondition);
            
    //        // Vector3 represents a position point (object position or any point in space) this include X, Y, and Z
    //        IsFacingRule isFacing = new IsFacingRule(threshold, Entities, new System.Numerics.Vector3(0, 0, 0), testCondition);

    //        // all available compound rules, I used the ones I declared above but you can create the rule directly in the compound rule
    //        // Example of creating the rule direclty is in the NOTRule below
    //        // we basicly apply the four operations on the rules

    //        ANDRule _ANDRule = new ANDRule(relativeOrientation, relativeDistance);

    //        ORRule _OrRule = new ORRule(relativeOrientation, relativeDistance);

    //        XORRule _XORRule = new XORRule(relativeOrientation, relativeDistance);

    //        NOTRule _NOTRule = new NOTRule(new IsFacingRule(threshold, Entities, new System.Numerics.Vector3(0, 0, 0), testCondition));

    //        // Hybrid rule

    //        HybridRule hybridRule = new HybridRule(_ANDRule);

    //        // current F-formation that we have in PUI
    //        CircularFformation fformation = new CircularFformation(new System.Numerics.Vector3(0, 0, 0), 4, Entities);*/


    //        while (true)
    //        {
    //            if (Entities.Count >= 2)
    //            {
    //                /*RelativeOrientationRule RelativeOrientation = new RelativeOrientationRule(45, Entities, Entities, "ANY");
    //                RuleEngine.Instance.AddToRuleList(RelativeOrientation);
    //                RelativeOrientation.OnEventTrue += RelativeOrientation_OnEventTrue;
    //                RelativeOrientation.OnEventFalse += RelativeOrientation_OnEventFalse;*/
    //                /*string id = Entities[2];
    //                IsFacingRule isFacingRule = new IsFacingRule(45, id, new System.Numerics.Vector3(0, 0, 0));
    //                RuleEngine.Instance.AddToRuleList(isFacingRule);
    //                isFacingRule.OnEventTrue += IsFacingRule_OnEventTrue;
    //                isFacingRule.OnEventFalse += IsFacingRule_OnEventFalse;*/

    //                CircularFformation fformation = new CircularFformation(new System.Numerics.Vector3(0, 0, 0), 4, Entities);
    //                RuleEngine.Instance.AddToFormationList(fformation);
    //                fformation.OnFormationCompleted += Fformation_OnFormationCompleted;
    //                /*RelativeDistanceRule relativeDistanceRule = new RelativeDistanceRule(0, 4, Entities, Entities, "ANY");
    //                RuleEngine.Instance.AddToRuleList(relativeDistanceRule);
    //                relativeDistanceRule.OnEventTrue += RelativeDistanceRule_OnEventTrue;
    //                relativeDistanceRule.OnEventFalse += RelativeDistanceRule_OnEventFalse;*/
    //                break;
    //            }
    //        }
    //    }

    //    private void Fformation_OnFormationCompleted(Fformation fformation, ProximityEventArgs proximityEvent)
    //    {
    //        FformationEventArgs eventArgs = (FformationEventArgs)proximityEvent;
            

    //        this.Dispatcher.Invoke(() =>
    //        {
    //            textBlock.Text = "";

    //            foreach (var item in eventArgs.TuplesForFformation)
    //            {
    //                textBlock.Text = "ID:   " + item.Item1 + "\n\nPos:   " + item.Item2.X + ", " + item.Item2.Y + ", " + item.Item2.Z +
    //                "\n\nOri:     " + item.Item3.Yaw + ", " + item.Item3.Pitch + ", " + item.Item3.Roll;
    //            }
    //        });
    //    }

    //    private void IsFacingRule_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    //    {
    //        this.Dispatcher.Invoke(() =>
    //        {
    //            _canvas.Background = Brushes.Red;
    //            textBlock.Text = "";
    //        });
    //    }

    //    private void IsFacingRule_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    //    {
    //        RelativeBasicProximityEventArgs eventArgs = (RelativeBasicProximityEventArgs)proximityEvent;

    //        this.Dispatcher.Invoke(() =>
    //        {
    //            _canvas.Background = Brushes.Green;
    //            textBlock.Text = "";
    //            foreach (string entity in eventArgs.EntityListForIsFacing)
    //            {
    //                textBlock.Text += entity + "     ";
    //            }
    //        });
    //    }

    //    private void RelativeOrientation_OnEventFalse(Rules rule, ProximityEventArgs proximityEvent)
    //    {
    //        this.Dispatcher.Invoke(() =>
    //        {
    //            _canvas.Background = Brushes.Red;
    //        });
    //    }

    //    private void RelativeOrientation_OnEventTrue(Rules rule, ProximityEventArgs proximityEvent)
    //    {
    //        RelativeBasicProximityEventArgs eventArgs = (RelativeBasicProximityEventArgs)proximityEvent;

    //        this.Dispatcher.Invoke(() =>
    //        {
    //            _canvas.Background = Brushes.Green;
    //        });


    //        foreach (KeyValuePair<string, List<string>> pair in eventArgs.EntityDictionaryForAny)
    //        {
    //            Console.WriteLine(pair.Key + " is facing " + pair.Value);
    //        }

    //    }
    //}
}
