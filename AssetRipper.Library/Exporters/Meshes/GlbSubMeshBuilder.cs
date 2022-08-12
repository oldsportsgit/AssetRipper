﻿using AssetRipper.Core.Classes.Mesh;
using AssetRipper.Core.Logging;
using AssetRipper.Core.Math.Transformations;
using AssetRipper.Core.Math.Vectors;
using AssetRipper.Core.SourceGenExtensions;
using AssetRipper.SourceGenerated.Subclasses.SubMesh;
using SharpGLTF.Geometry;
using SharpGLTF.Geometry.VertexTypes;
using SharpGLTF.Materials;
using System.Numerics;
using System.Runtime.CompilerServices;

namespace AssetRipper.Library.Exporters.Meshes
{
	internal static class GlbSubMeshBuilder
	{
		public static IMeshBuilder<MaterialBuilder> BuildSubMesh(MaterialBuilder material, MeshData meshData, ISubMesh subMesh, Transformation transform, Transformation inverseTransform)
		{
			BuildSubMeshParameters parameters = new BuildSubMeshParameters(material, meshData, subMesh, transform, inverseTransform);
			switch (meshData.MeshType)
			{
				case GlbMeshType.Position | GlbMeshType.Empty | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexEmpty, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Empty | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexEmpty, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Empty | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexEmpty, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexTexture1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexTexture1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexTexture1, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexTexture2, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexTexture2, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexTexture2, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexColor1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexColor1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexColor1Texture1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexColor1Texture1, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1Texture1 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1Texture1, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPosition, VertexColor1Texture2, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormal, VertexColor1Texture2, VertexEmpty>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1Texture2 | GlbMeshType.Empty:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1Texture2, VertexEmpty>(parameters);

				case GlbMeshType.Position | GlbMeshType.Empty | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexEmpty, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Empty | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexEmpty, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Empty | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexEmpty, VertexJoints4>(parameters);

				case GlbMeshType.Position | GlbMeshType.Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexTexture1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexTexture1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexTexture1, VertexJoints4>(parameters);

				case GlbMeshType.Position | GlbMeshType.Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexTexture2, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexTexture2, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexTexture2, VertexJoints4>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexColor1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexColor1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1, VertexJoints4>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexColor1Texture1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexColor1Texture1, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1Texture1 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1Texture1, VertexJoints4>(parameters);

				case GlbMeshType.Position | GlbMeshType.Color1Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPosition, VertexColor1Texture2, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormal | GlbMeshType.Color1Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormal, VertexColor1Texture2, VertexJoints4>(parameters);
				case GlbMeshType.PositionNormalTangent | GlbMeshType.Color1Texture2 | GlbMeshType.Joints4:
					return BuildSubMesh<VertexPositionNormalTangent, VertexColor1Texture2, VertexJoints4>(parameters);

				default:
					throw new ArgumentOutOfRangeException(nameof(meshData), meshData.MeshType, "Mesh type not supported.");
			}
		}

		private readonly record struct BuildSubMeshParameters(MaterialBuilder Material, MeshData MeshData, ISubMesh SubMesh, Transformation Transform, Transformation InverseTransform)
		{
		}

		private static MeshBuilder<TvG, TvM, TvS> BuildSubMesh<TvG, TvM, TvS>(BuildSubMeshParameters parameters)
			where TvG : unmanaged, IVertexGeometry
			where TvM : unmanaged, IVertexMaterial
			where TvS : unmanaged, IVertexSkinning
		{
			MaterialBuilder material = parameters.Material;
			MeshData meshData = parameters.MeshData;
			ISubMesh subMesh = parameters.SubMesh;
			Transformation positionTransform = parameters.Transform;
			Transformation tangentTransform = positionTransform.RemoveTranslation();
			Transformation normalTransform = parameters.InverseTransform.Transpose();

			uint firstIndex = meshData.Mesh.Is16BitIndices() ? subMesh.FirstByte / 2 : subMesh.FirstByte / 4;

			uint indexCount = subMesh.IndexCount;
			MeshTopology topology = subMesh.GetTopology();
			if (topology != MeshTopology.Triangles && meshData.Mesh.SerializedFile.Version.IsLess(4))
			{
				topology = MeshTopology.TriangleStrip;
			}

			MeshBuilder<TvG, TvM, TvS> meshBuilder = VertexBuilder<TvG, TvM, TvS>.CreateCompatibleMesh();
			int primitiveVertexCount = topology switch
			{
				MeshTopology.Lines or MeshTopology.LineStrip => 2,
				MeshTopology.Points => 1,
				_ => 3
			};
			PrimitiveBuilder<MaterialBuilder, TvG, TvM, TvS> primitiveBuilder = meshBuilder.UsePrimitive(material, primitiveVertexCount);

			switch (topology)
			{
				case MeshTopology.Triangles:
					{
						for (int i = 0; i < indexCount; i += 3)
						{
							primitiveBuilder.AddTriangle(
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + i], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + i + 1], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + i + 2], positionTransform, normalTransform, tangentTransform));
						}
					}
					break;

				case MeshTopology.TriangleStrip:
					{
						// de-stripify :
						uint triIndex = 0;
						for (int i = 0; i < indexCount - 2; i++)
						{
							uint a = meshData.ProcessedIndexBuffer[firstIndex + i];
							uint b = meshData.ProcessedIndexBuffer[firstIndex + i + 1];
							uint c = meshData.ProcessedIndexBuffer[firstIndex + i + 2];

							// skip degenerates
							if (a == b || a == c || b == c)
							{
								continue;
							}

							// do the winding flip-flop of strips :
							if ((i & 1) == 1)
							{
								primitiveBuilder.AddTriangle(
									GetVertex<TvG, TvM, TvS>(meshData, b, positionTransform, normalTransform, tangentTransform),
									GetVertex<TvG, TvM, TvS>(meshData, a, positionTransform, normalTransform, tangentTransform),
									GetVertex<TvG, TvM, TvS>(meshData, c, positionTransform, normalTransform, tangentTransform));
							}
							else
							{
								primitiveBuilder.AddTriangle(
									GetVertex<TvG, TvM, TvS>(meshData, a, positionTransform, normalTransform, tangentTransform),
									GetVertex<TvG, TvM, TvS>(meshData, b, positionTransform, normalTransform, tangentTransform),
									GetVertex<TvG, TvM, TvS>(meshData, c, positionTransform, normalTransform, tangentTransform));
							}
							triIndex += 3;
						}
					}
					break;

				case MeshTopology.Quads:
					{
						for (int q = 0; q < indexCount; q += 4)
						{
							primitiveBuilder.AddQuadrangle(
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + q], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + q + 1], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + q + 2], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + q + 3], positionTransform, normalTransform, tangentTransform));
						}
					}
					break;

				case MeshTopology.Lines:
					{
						for (int l = 0; l < indexCount; l += 2)
						{
							primitiveBuilder.AddLine(
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + l], positionTransform, normalTransform, tangentTransform),
								GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + l + 1], positionTransform, normalTransform, tangentTransform));
						}
					}
					break;

				case MeshTopology.LineStrip:
					Logger.Warning(LogCategory.Export, "LineStrip is not yet supported for GLB mesh export.");
					break;

				case MeshTopology.Points:
					{
						for (int p = 0; p < indexCount; p++)
						{
							primitiveBuilder.AddPoint(GetVertex<TvG, TvM, TvS>(meshData, meshData.ProcessedIndexBuffer[firstIndex + p], positionTransform, normalTransform, tangentTransform));
						}
					}
					break;
			}

			return meshBuilder;
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		private static VertexBuilder<TvG, TvM, TvS> GetVertex<TvG, TvM, TvS>(MeshData meshData, uint index,
			Transformation positionTransform, Transformation normalTransform, Transformation tangentTransform)
			where TvG : unmanaged, IVertexGeometry
			where TvM : unmanaged, IVertexMaterial
			where TvS : unmanaged, IVertexSkinning
		{
			TvG geometry = GetGeometry<TvG>(meshData, index, positionTransform, normalTransform, tangentTransform);
			TvM material = GetMaterial<TvM>(meshData, index);
			TvS skin = GetSkin<TvS>(meshData, index);
			return new VertexBuilder<TvG, TvM, TvS>(geometry, material, skin);
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		private static TvG GetGeometry<TvG>(MeshData meshData, uint index, Transformation positionTransform, Transformation normalTransform, Transformation tangentTransform)
			where TvG : unmanaged, IVertexGeometry
		{
			Vector3 position = meshData.TryGetVertexAtIndex(index) * positionTransform;
			if (typeof(TvG) == typeof(VertexPosition))
			{
				return Cast<VertexPosition, TvG>(new VertexPosition(position));
			}
			else if (typeof(TvG) == typeof(VertexPositionNormal))
			{
				Vector3 normal = Vector3.Normalize(meshData.TryGetNormalAtIndex(index) * normalTransform);
				return Cast<VertexPositionNormal, TvG>(new VertexPositionNormal(position, normal));
			}
			else if (typeof(TvG) == typeof(VertexPositionNormalTangent))
			{
				Vector3 normal = Vector3.Normalize(meshData.TryGetNormalAtIndex(index) * normalTransform);
				Vector4 originalTangent = meshData.TryGetTangentAtIndex(index);
				Vector3 transformedTangent = Vector3.Normalize(originalTangent.AsVector3() * tangentTransform);
				return Cast<VertexPositionNormalTangent, TvG>(new VertexPositionNormalTangent(position, normal, new Vector4(transformedTangent, originalTangent.W)));
			}
			else
			{
				return default;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		private static TvM GetMaterial<TvM>(MeshData meshData, uint index) where TvM : unmanaged, IVertexMaterial
		{
			if (typeof(TvM) == typeof(VertexTexture1))
			{
				return Cast<VertexTexture1, TvM>(new VertexTexture1(meshData.TryGetUV0AtIndex(index)));
			}
			else if (typeof(TvM) == typeof(VertexTexture2))
			{
				return Cast<VertexTexture2, TvM>(new VertexTexture2(meshData.TryGetUV0AtIndex(index), meshData.TryGetUV1AtIndex(index)));
			}
			else if (typeof(TvM) == typeof(VertexColor1Texture1))
			{
				return Cast<VertexColor1Texture1, TvM>(new VertexColor1Texture1(meshData.TryGetColorAtIndex(index).Vector, meshData.TryGetUV0AtIndex(index)));
			}
			else if (typeof(TvM) == typeof(VertexColor1Texture2))
			{
				return Cast<VertexColor1Texture2, TvM>(new VertexColor1Texture2(meshData.TryGetColorAtIndex(index).Vector, meshData.TryGetUV0AtIndex(index), meshData.TryGetUV1AtIndex(index)));
			}
			else
			{
				return default;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		private static TvS GetSkin<TvS>(MeshData meshData, uint index) where TvS : unmanaged, IVertexSkinning
		{
			if (typeof(TvS) == typeof(VertexJoints4))
			{
				return default;
			}
			else
			{
				return default;
			}
		}

		[MethodImpl(MethodImplOptions.AggressiveInlining | MethodImplOptions.AggressiveOptimization)]
		private static TTo Cast<TFrom, TTo>(TFrom value) where TFrom : unmanaged where TTo : unmanaged
		{
			//Protect against accidental misuse
			//Branches will get optimized away by JIT
			if (typeof(TFrom) == typeof(TTo))
			{
				return Unsafe.As<TFrom, TTo>(ref value);
			}
			else
			{
#if DEBUG
				throw new InvalidCastException();
#else
				return default;
#endif
			}
		}
	}
}
