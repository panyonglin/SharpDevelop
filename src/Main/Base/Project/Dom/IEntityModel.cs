﻿// Copyright (c) AlphaSierraPapa for the SharpDevelop Team (for details please see \doc\copyright.txt)
// This code is distributed under the GNU LGPL (for details please see \doc\license.txt)

using System;
using System.ComponentModel;
using ICSharpCode.NRefactory.TypeSystem;
using ICSharpCode.SharpDevelop.Parser;
using ICSharpCode.SharpDevelop.Project;

namespace ICSharpCode.SharpDevelop.Dom
{
	/// <summary>
	/// An NRefactory entity as a model.
	/// </summary>
	public interface IEntityModel : INotifyPropertyChanged
	{
		/// <summary>
		/// Gets the parent project that contains this entity.
		/// May return null if the entity is not part of a project.
		/// </summary>
		IProject ParentProject { get; }
		
		/// <summary>
		/// Gets the region where this entity is defined.
		/// </summary>
		DomRegion Region { get; }
		
		/// <summary>
		/// Resolves the entity in the current solution snapshot.
		/// Returns null if the entity could not be resolved.
		/// </summary>
		IEntity Resolve();
		
		/// <summary>
		/// Resolves the entity in the specified solution snapshot.
		/// Returns null if the entity could not be resolved.
		/// </summary>
		IEntity Resolve(ISolutionSnapshotWithProjectMapping solutionSnapshot);
	}
}