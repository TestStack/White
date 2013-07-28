using System.Collections.Generic;
using System.Reflection;
using Castle.Core.Logging;
using TestStack.White.Configuration;
using TestStack.White.Mappings;
using TestStack.White.ScreenObjects.EntityMapping;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace TestStack.White.ScreenObjects
{
    //TODO: Provider some mechanism to log/inform about whether there are any errors on the screen or not.
    //TODO: Take care of act kind of stuff by putting attribute
    public class AppScreen : RepositoryComponent
    {
        private readonly ILogger logger = CoreAppXmlConfiguration.Instance.LoggerFactory.Create(typeof(AppScreen));

        public AppScreen(Window window, ScreenRepository screenRepository) : base(window, screenRepository) {}

        public virtual string WindowTitle
        {
            get { return Window.Title; }
        }

        public virtual bool IsClosed
        {
            get { return Window.IsClosed; }
        }

        public virtual void Focus()
        {
            Window.Focus();
        }

        public virtual void Close()
        {
            ScreenRepository.Closing(this);
            Window.Close();
        }

        public override string ToString()
        {
            return GetType().Name + ":" + Window.Title;
        }

        protected virtual void ScreenChanged()
        {
            ScreenRepository.SessionReport.Act();
        }

        public virtual void Focus(DisplayState displayState)
        {
            Window.Focus(displayState);
        }

        public virtual void Populate(IFieldMap fieldMap, Entity entity)
        {
            var fieldsWithNoValueOnEntity = new List<string>();

            foreach (var fieldInfo in GetType().GetFields())
            {
                var uiItem = fieldInfo.GetValue(this) as UIItem;
                if (uiItem == null || !ControlDictionary.Instance.IsEditable(uiItem)) return;

                string fieldName = fieldMap.GetFieldNameFor(fieldInfo.Name, fieldInfo.FieldType);
                if (string.IsNullOrEmpty(fieldName)) return;

                try
                {
                    EntityField entityField = entity.Field(fieldName);
                    if (entityField == null)
                        fieldsWithNoValueOnEntity.Add(fieldName);
                    else
                        entityField.SetValueOn(uiItem);
                }
                catch (TargetInvocationException e)
                {
                    throw new AppScreenException(
                        string.Format("Error assigning {0}.{1} to {2}.{3} ", entity.GetType(), fieldName, GetType(), fieldInfo.Name),
                        e.InnerException);
                }
            }

            if (fieldsWithNoValueOnEntity.Count == 0) return;
            
            string message = string.Join(",", fieldsWithNoValueOnEntity.ToArray());
            logger.WarnFormat("Mapping to screen: {0} with {1}, No value specified for fields {2}", this, entity.GetType(), message);
        }
    }
}