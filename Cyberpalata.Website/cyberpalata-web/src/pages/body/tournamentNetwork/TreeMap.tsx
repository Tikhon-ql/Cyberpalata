import React from 'react';
import './../tournament/custom-tree.css';
import { useCenteredTree } from "./../tournament/helpers";
import { TreeData } from '../../../types/types';
import Tree from 'react-d3-tree';
import api from './../../../Components/api';
import { useNavigate } from 'react-router-dom';
import jwtDecode from 'jwt-decode';
// import {Node} from './Node';

export type Props = {
    tournamentId: string,
    treeData: TreeData  
}

const svgSquare = {
    shape: 'rect',
    shapeProps: {
      width: 20,
      height: 20,
      x: -10,
      y: -10,
    }
}

const containerStyles = {
    width: "100vw",
    height: "100vh",
    background: "#eee"
};

const renderForeignObjectNode = ({
    nodeDatum,
    toggleNode,
    foreignObjectProps
  }) => (
    <g>
      <circle r={15}></circle>
      {/* `foreignObject` requires width & height to be explicitly set. */}
      <foreignObject {...foreignObjectProps}>
        <div style={{ border: "1px solid black", backgroundColor: "#dedede" }}>
          <h3 style={{ textAlign: "center" }}>{nodeDatum.name}</h3>
          {nodeDatum.children && (
            <button style={{ width: "100%" }} onClick={toggleNode}>
              {nodeDatum.__rd3t.collapsed ? "Expand" : "Collapse"}
            </button>
          )}
        </div>
      </foreignObject>
    </g>
  );
  
export const TreeMap = ({treeData, tournamentId}:Props)=>{
    const separation = { siblings: 3, nonSiblings: 3};
    const nodeSize = { x: 100, y: 100 };
    const foreignObjectProps = { width: nodeSize.x, height: nodeSize.y, x: -125 };
    const [translate, containerRef] = useCenteredTree();
    const navigate = useNavigate();
    let accessToken: any;
    if(localStorage.getItem('accessToken'))
    {
        accessToken = jwtDecode(localStorage.getItem('accessToken') || "");
    }

    function nodeClicked(e)
    {
      console.dir(e);
      if(e.data.batleId && e.data.firstTeamName && e.data.firstTeamId && e.data.secondTeamName && e.data.secondTeamId)
      {
         navigate(`/selectWinner/${tournamentId}/${e.data.batleId}/${e.data.firstTeamName}/${e.data.firstTeamId}/${e.data.secondTeamName}/${e.data.secondTeamId}`);
      }

      // var requestBody = {
      //   batleId: treeData.batleId,
      //   winnerId: 
      // }
      // api.post(`/batles/sendBatleWinner`);
    }

    return (
        <div id="treeWrapper" style={containerStyles}>
            <Tree  data={treeData}
            nodeSize={nodeSize}
            separation={separation}
            transitionDuration = {1000}
            pathFunc="step"
            rootNodeClassName="node__root"
            branchNodeClassName="node__branch"
            leafNodeClassName="node__leaf"
            orientation="vertical"
            translate={{ x: 900, y: 150 }}
            onNodeClick = {accessToken?.role === "Admin" ? (e)=>{nodeClicked(e)} : (e)=>{}}
            // nodeLabelComponent={{
            //   render: <Node/>,
            //   foreignObjectWrapper: {
            //     width: 220,
            //     height: 200,
            //     y: -50,
            //     x: -100
            //   }
            // }}
            />
        </div>
    )
}