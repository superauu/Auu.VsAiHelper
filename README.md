# Copy Code Context Info (Visual Studio Extension)

A Visual Studio 2022 extension that allows you to quickly copy the context of a selected code block (full file path, class name, method name, and line numbers) to the clipboard. This is particularly useful for code reviews, documentation, bug reporting, and sharing code snippets with context.

---

## Features

- Adds a **"Copy Code Context Info"** command to the code editor's right-click context menu.
- Automatically extracts:
  - The absolute file path.
  - The containing class name (defaults to `UnknownClass`).
  - The containing method name (defaults to `UnknownMethod`).
  - The start and end line numbers of the selection.
- Formats the information and copies it to the clipboard in one click.

## Usage

1.  Open any code file in the Visual Studio editor.
2.  Select a block of code.
3.  Right-click on your selection to open the context menu.
4.  Find and click on the **"Copy Code Context Info"** menu item.
5.  The context information is now on your clipboard, ready to be pasted.

**Example Output:**
```
File: C:\Projects\MySolution\MyApp\Program.cs
Class: Program
Method: Main
Lines: 15 - 20
```

<img width="356" height="180" alt="image" src="https://github.com/user-attachments/assets/2b6faa56-5e04-467e-bbed-ff143db7c1c2" />


## Building from Source

1.  Clone this repository.
2.  Open the `VsAiHelper.sln` file in Visual Studio 2022.
3.  Ensure you have the **"Visual Studio extension development"** workload installed via the Visual Studio Installer.
4.  Build the solution (F6 or `Build > Build Solution`).
5.  The `.vsix` installer will be generated in the `bin\Debug` or `bin\Release` folder.

---
---

# 复制带上下文的代码信息 (Visual Studio 插件)

这是一个 Visual Studio 2022 扩展，允许您快速将选中代码块的上下文（完整文件路径、类名、方法名和行号）复制到剪贴板。它对于代码审查、编写文档、Bug 报告以及分享代码片段等场景非常有用。

---

## 功能特性

- 在代码编辑器的右键菜单中添加一个 **"Copy Code Context Info"** 命令。
- 自动提取以下信息：
  - 文件的绝对路径。
  - 所在的类名（如果未找到，则默认为 `UnknownClass`）。
  - 所在的方法名（如果未找到，则默认为 `UnknownMethod`）。
  - 选中范围的起始和结束行号。
- 一键将格式化后的信息复制到剪贴板。

## 使用方法

1.  在 Visual Studio 编辑器中打开任意代码文件。
2.  选择一个或多个代码行。
3.  在选中的代码上右键单击，打开上下文菜单。
4.  找到并点击 **"Copy Code Context Info"** 菜单项。
5.  代码的上下文信息即被复制到您的剪贴板，随时可以粘贴。

**输出示例:**
```
File: C:\Projects\MySolution\MyApp\Program.cs
Class: Program
Method: Main
Lines: 15 - 20
```

<img width="356" height="180" alt="image" src="https://github.com/user-attachments/assets/e51c7019-1167-4314-9e76-feb0445d1908" />


## 从源码构建

1.  克隆此代码仓库。
2.  使用 Visual Studio 2022 打开 `VsAiHelper.sln` 解决方案文件。
3.  通过 Visual Studio Installer 确保您已经安装了 **"Visual Studio extension development"** (Visual Studio 扩展开发) 工作负载。
4.  生成解决方案 (F6 或 `生成 > 生成解决方案`)。
5.  `.vsix` 安装包将生成在 `bin\Debug` 或 `bin\Release` 目录下。
