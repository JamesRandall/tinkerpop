/*
 * Licensed to the Apache Software Foundation (ASF) under one
 * or more contributor license agreements.  See the NOTICE file
 * distributed with this work for additional information
 * regarding copyright ownership.  The ASF licenses this file
 * to you under the Apache License, Version 2.0 (the
 * "License"); you may not use this file except in compliance
 * with the License.  You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing,
 * software distributed under the License is distributed on an
 * "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
 * KIND, either express or implied.  See the License for the
 * specific language governing permissions and limitations
 * under the License.
 */
package org.apache.tinkerpop.gremlin.process.traversal.step;


import org.apache.tinkerpop.gremlin.process.traversal.step.util.MutatingContainer;
import org.apache.tinkerpop.gremlin.process.traversal.step.util.event.CallbackRegistry;
import org.apache.tinkerpop.gremlin.process.traversal.step.util.event.Event;
import org.apache.tinkerpop.gremlin.structure.Graph;
import org.apache.tinkerpop.gremlin.structure.Vertex;

import java.util.List;

/**
 * @author Stephen Mallette (http://stephen.genoprime.com)
 */
public interface MutatingContainerHolder {

    public List<MutatingContainer> getMutatingContainers();

    public default MutatingContainer getLastMutatingContainer() {
        final List<MutatingContainer> containers = getMutatingContainers();
        return containers.get(containers.size() - 1);
    }

    public void addMutatingContainer(final MutatingContainer mutatingContainer);

    public default void removeMutatingContainer(final MutatingContainer mutatingContainer) {
        throw new UnsupportedOperationException("The holder does not support container removal: " + this.getClass().getCanonicalName());
    }

    public CallbackRegistry<Event> getMutatingCallbackRegistry();

    public Vertex getLabelledVertex(final String label);

    public Graph getGraph();
}
