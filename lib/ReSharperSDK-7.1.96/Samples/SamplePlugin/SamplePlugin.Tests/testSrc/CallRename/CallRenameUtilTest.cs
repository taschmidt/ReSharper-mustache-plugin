﻿/*
 * Copyright 2007-2011 JetBrains s.r.o.
 *
 * Licensed under the Apache License, Version 2.0 (the "License");
 * you may not use this file except in compliance with the License.
 * You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using JetBrains.ProjectModel;
using JetBrains.ReSharper.Psi;
using JetBrains.ReSharper.Psi.Services;
using JetBrains.ReSharper.SamplePlugin.CallRename;
using JetBrains.ReSharper.TestFramework;
using JetBrains.TextControl;
using NUnit.Framework;
using System.Linq;

namespace JetBrains.ReSharper.SamplePlugin.Tests.CallRename
{
  public class CallRenameUtilTest : BaseTestWithTextControl
  {
    protected override string RelativeTestDataPath
    {
      get { return "CallRename"; }
    }

    protected override void DoTest(IProject testProject)
    {
      CaretPosition caretPos = GetCaretPosition();
      using (ITextControl textControl = OpenTextControl(testProject, caretPos))
      {
        IDeclaredElement declaredElement = TextControlToPsi.GetDeclaredElements(Solution, textControl).FirstOrDefault();
        Assert.IsNotNull(declaredElement);

        Solution.GetComponent<CallRenameUtil>().CallRename(declaredElement, textControl, "xxx");

        CheckTextControl(textControl);
      }
    }

    [Test]
    public void Test()
    {
      DoTestFiles("test01.cs");
    }
  }
}