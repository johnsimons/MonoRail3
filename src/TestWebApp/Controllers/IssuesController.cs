namespace TestWebApp.Controllers
{
    using System;
    using Castle.MonoRail;
    using Model;

    public class IssuesController : Controller
    {
        // [HttpVerb(HttpVerb.Get)]
        public ActionResult Index()
        {
            var issues = new Issue[] { new Issue(), new Issue() };

            // return issues;
            return null;
        }

        // [HttpVerb(HttpVerb.Get)]
        public void New()
        {
            // only makes sense for html
        }

        // [HttpVerb(HttpVerb.Post)]
        public Issue Create()
        {
            // var issue = service.Create(..);
            var issue = new Issue();

            RespondTo( format => 
                format.Html(  )
                    .Js()
                    .Xml()
                    .JSon()
                );

            return issue;
        }

//        public void Edit(string key)
//        {
//            try
//            {
//                Issue issue = null;
//
//                if (!Flash.ContainsKey("issue"))
//                {
//                    issue = issueService.Find(key, CurrentProject, CurrentUser);
//                }
//                else
//                {
//                    issue = (Issue)Flash["issue"];
//                }
//
//                PropertyBag["issue"] = issue;
//
//                PropertyBag["fieldcontainers"] = dynamicFieldService.GetFieldsFor(CurrentProject,
//                                                                                  IssueTrackingFeature.FeatureKey,
//                                                                                  typeof(Issue),
//                                                                                  IssueTrackingFeature.Forms.New);
//
//                PropertyBag["policiesModels"] = policyService.GetAvailablePolicies();
//
//                PropertyBag["voted"] = votingService.HasUserVoted(issue, CurrentUser);
//            }
//            catch (SecurityException ex)
//            {
//                Flash["message"] = ex.Message;
//                RegisterExceptionAndNotifyExtensions(ex);
//                RedirectUsingNamedRoute("maindashboard");
//            }
//        }
//
//        [AccessibleThrough(Verb.Post)]
//        public void Create(
//            [ARDataBind("issue", AutoLoadBehavior.OnlyNested, From = ParamStore.Form, Validate = true)] Issue issue,
//            string comment,
//            string nextaction)
//        {
//
//            if (HasValidationError(issue))
//            {
//                Flash["errors"] = GetErrorSummary(issue);
//                Flash["issue"] = issue;
//
//                RedirectUsingRoute("new", new { project = CurrentProjectKey });
//
//                return;
//            }
//
//            try
//            {
//
//                List<SimpleFileAttachment> attachments = new List<SimpleFileAttachment>();
//
//                for (int i = 0; i < Context.UnderlyingContext.Request.Files.Count; i++)
//                {
//                    HttpPostedFile file = Context.UnderlyingContext.Request.Files[i];
//
//                    if (file.ContentLength == 0)
//                        continue;
//
//                    attachments.Add(new SimpleFileAttachment(file.FileName, file.ContentType, file.ContentLength, file.InputStream));
//                }
//
//                issueService.Create(issue, CurrentProject, CurrentUser,
//                                    (CompositeNode)Request.FormNode.GetChildNode("issue"), comment, attachments);
//
//
//                RedirectedBasedOnNextAction(nextaction, issue.Key);
//            }
//            catch (Exception ex)
//            {
//                Flash["exception"] = ex.Message;
//                Flash["issue"] = issue;
//
//                RegisterExceptionAndNotifyExtensions(ex);
//
//                Logger.Debug("Error creating issue", ex);
//
//                RedirectUsingRoute("new", new { project = CurrentProjectKey });
//            }
//        }
//
//        [AccessibleThrough(Verb.Post)]
//        public void Update(
//            [ARDataBind("issue", AutoLoadBehavior.OnlyNested, From = ParamStore.Form, Validate = true)] Issue issue,
//            string comment,
//            string nextaction)
//        {
//            if (HasValidationError(issue))
//            {
//                Flash["errors"] = GetErrorSummary(issue);
//                Flash["issue"] = issue;
//                RedirectUsingRoute("edit", new { project = CurrentProjectKey, key = issue.Key });
//                return;
//            }
//
//            try
//            {
//                issueService.Update(issue.Key, issue.Policies, CurrentProject, CurrentUser,
//                                    (CompositeNode)Request.FormNode.GetChildNode("issue"), comment);
//
//                RedirectedBasedOnNextAction(nextaction, issue.Key);
//            }
//            catch (Exception ex)
//            {
//                Flash["exception"] = ex.Message;
//                Flash["issue"] = issue;
//                RegisterExceptionAndNotifyExtensions(ex);
//                RedirectUsingRoute("edit", new { project = CurrentProjectKey, key = issue.Key });
//            }
//        }
//
//        [AccessibleThrough(Verb.Post)]
//        public void Delete(string key)
//        {
//            try
//            {
//                issueService.Delete(key, CurrentProject, CurrentUser);
//
//                RenderText("OK");
//            }
//            catch (Exception ex)
//            {
//                Flash["exception"] = ex.Message;
//                RegisterExceptionAndNotifyExtensions(ex);
//                RedirectUsingRoute("view", new { project = CurrentProjectKey, key = key });
//            }
//        }
//
//        [AccessibleThrough(Verb.Post)]
//        public void AddComment(string key, string comment)
//        {
//            try
//            {
//                Issue issue = issueService.Find(key, CurrentProject, CurrentUser);
//
//                Comment newComment = commentService.AddComment(issue, comment, CurrentUser);
//
//                PropertyBag["comment"] = newComment;
//            }
//            catch (Exception ex)
//            {
//                RegisterExceptionAndNotifyExtensions(ex);
//                PropertyBag["error"] = ex;
//            }
//        }
//
//        [AccessibleThrough(Verb.Post)]
//        public void AddFiles(string key)
//        {
//            CancelLayout();
//
//            try
//            {
//                Issue issue = issueService.Find(key, CurrentProject, CurrentUser);
//
//                List<SimpleFileAttachment> attachments = new List<SimpleFileAttachment>();
//
//                for (int i = 0; i < Context.UnderlyingContext.Request.Files.Count; i++)
//                {
//                    HttpPostedFile file = Context.UnderlyingContext.Request.Files[i];
//
//                    if (file.ContentLength == 0)
//                        continue;
//
//                    attachments.Add(new SimpleFileAttachment(file.FileName, file.ContentType, file.ContentLength, file.InputStream));
//                }
//
//                attachmentService.AddAttachments(issue, CurrentUser, attachments.ToArray());
//
//                PropertyBag["issue"] = issue;
//                PropertyBag["attachments"] = attachmentService.GetAttachmentsFor(issue);
//            }
//            catch (Exception ex)
//            {
//                RegisterExceptionAndNotifyExtensions(ex);
//                PropertyBag["error"] = ex;
//            }
//        }
//
//        public void DownloadAttachment(string key, string name, bool inline)
//        {
//            try
//            {
//                Issue issue = issueService.Find(key, CurrentProject, CurrentUser);
//
//                Attachment attachment = attachmentService.GetAttachment(issue, CurrentUser, name);
//
//                if (attachment == null || !attachment.FileExists)
//                {
//                    RenderSharedView("shared/error404", false);
//                }
//                else
//                {
//                    CancelView();
//
//                    Response.ContentType = attachment.MimeType;
//                    Response.AppendHeader("Content-length", attachment.Size.ToString());
//
//                    if (!inline)
//                    {
//                        Response.AppendHeader("Content-disposition", "attachment; filename=" + attachment.Name);
//                    }
//
//                    using (FileStream fs = attachment.OpenFile())
//                    {
//                        byte[] buffer = new byte[attachment.Size];
//                        fs.Read(buffer, 0, buffer.Length);
//                        Response.BinaryWrite(buffer);
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                RegisterExceptionAndNotifyExtensions(ex);
//                PropertyBag["error"] = ex;
//                Response.StatusCode = 404;
//                RenderSharedView("shared/error404", false);
//            }
//        }





    }
}